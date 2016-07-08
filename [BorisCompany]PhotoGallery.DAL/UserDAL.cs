namespace _BorisCompany_PhotoGallery.DAL.DB
{
    using Interfaces.DAL;
    using System;
    using System.Collections.Generic;
    using Entites;
    using System.Data.SqlClient;
    using System.Configuration;
    using System.Security.Cryptography;
    using System.Text;
    using System.Linq;
    using log4net;

    public class UserDAL : IUserDAL
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
        private static readonly ILog logger = LogManager.GetLogger(typeof(UserDAL));

        public bool ChangePassword(Guid id, string password)
        {
            if (string.IsNullOrWhiteSpace(password)) return false;
            SHA512Managed sham = new SHA512Managed();
            byte[] s = Encoding.UTF8.GetBytes(password);
            byte[] res = sham.ComputeHash(s);

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = "User_Change_Password";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@Password", res);
                    connection.Open();
                    var result = command.ExecuteNonQuery();
                    if (result != 0) return false;
                }
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }
            return true;
        }

        public bool Create(string login, string password)
        {
            if (string.IsNullOrWhiteSpace(login) && string.IsNullOrWhiteSpace(password)) return false;
            SHA512Managed sham = new SHA512Managed();
            byte[] s = Encoding.UTF8.GetBytes(password);
            byte[] res = sham.ComputeHash(s);

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    Guid id = Guid.NewGuid();
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = "User_Add";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@Login", login);
                    command.Parameters.AddWithValue("@Password", res);
                    connection.Open();
                    var result = command.ExecuteNonQuery();
                    if (result != 0) return false;
                }
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }
            return true;
        }

        public bool Delete(Guid id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = "User_Delete";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", id);
                    connection.Open();
                    var result = command.ExecuteNonQuery();
                    if (result != 0) return false;
                }
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }
            return true;
        }

        public IEnumerable<UserDTO> GetAllUser()
        {
            List<UserDTO> users = new List<UserDTO>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataReader reader = null;
                try
                {
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = "User_Get_All";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    connection.Open();
                    reader = command.ExecuteReader();
                }
                catch(Exception e)
                {
                    logger.Error(e.Message);
                }
                while (reader.Read())
                {
                    Guid id = (Guid)reader["Id"];
                    string login = (string)reader["Login"];
                    byte[] password = (byte[])reader["Password"];
                    int idRole = (int)reader["Id_role"];
                    UserDTO user = new UserDTO(id, login, password, idRole);
                    users.Add(user);
                }
            }
            foreach (var item in users)
            {
                yield return item;
            }
        }

        public UserDTO GetUser(string login)
        {
            UserDTO user = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataReader reader = null;
                try
                {
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = "User_Get";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Login", login);
                    connection.Open();
                    reader = command.ExecuteReader();
                }
                catch (Exception e)
                {
                    logger.Error(e.Message);
                }
                while (reader.Read())
                {
                    Guid _id = (Guid)reader["Id"];
                    string _login = (string)reader["Login"];
                    byte[] password = (byte[])reader["Password"];
                    int idRole = (int)reader["Id_role"];
                    user = new UserDTO(_id, _login, password, idRole);
                }
            }
            return user;
        }

        public UserDTO GetUser(Guid id)
        {
            UserDTO user = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataReader reader = null;
                try
                {
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = "User_Get_By_Id";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", id);
                    connection.Open();
                    reader = command.ExecuteReader();
                }
                catch (Exception e)
                {
                    logger.Error(e.Message);
                }
                while (reader.Read())
                {
                    Guid _id = (Guid)reader["Id"];
                    string _login = (string)reader["Login"];
                    byte[] password = (byte[])reader["Password"];
                    int idRole = (int)reader["Id_role"];
                    user = new UserDTO(_id, _login, password, idRole);
                }
            }
            return user;
        }

        public bool SearchUser(string login, string password)
        {
            bool search = false;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = "User_Search";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Login", login);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        byte[] _password = (byte[])reader["Password"];
                        SHA512Managed sham = new SHA512Managed();
                        byte[] s = Encoding.UTF8.GetBytes(password);
                        byte[] res = sham.ComputeHash(s);
                        search = _password.SequenceEqual(res);
                    }
                }
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }
            return search;
        }

        public bool ChangeRole(string login, int role)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = "User_Change_Role";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Role", role);
                    command.Parameters.AddWithValue("@Login", login);
                    connection.Open();
                    var result = command.ExecuteNonQuery();
                    if (result != 0) return false;
                }
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }
            return true;
        }
    }
}
