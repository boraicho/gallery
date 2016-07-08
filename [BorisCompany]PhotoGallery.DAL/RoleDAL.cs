namespace _BorisCompany_PhotoGallery.DAL.DB
{
    using Interfaces.DAL;
    using System;
    using System.Collections.Generic;
    using Entites;
    using System.Configuration;
    using System.Data.SqlClient;
    using log4net;

    public class RoleDAL : IRoleDAL
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
        private static readonly ILog logger = LogManager.GetLogger(typeof(RoleDAL));


        public bool AddRole(string name)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(name)) return false;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    Guid id = Guid.NewGuid();
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = "Role_Add";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Name", name);
                    connection.Open();
                    var result = command.ExecuteNonQuery();
                    if (result != 0) return false;
                }
            }
            catch(Exception e)
            {
                logger.Error(e.Message);
            }
            return true;
        }

        public IEnumerable<RoleDTO> GetAll()
        {
            List<RoleDTO> roles = new List<RoleDTO>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataReader reader = null;
                try
                {
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = "Role_Get_All";
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
                    int id = (int)reader["Id"];
                    string name = (string)reader["Name"];
                    RoleDTO user = new RoleDTO(id, name);
                    roles.Add(user);
                }
            }
            foreach (var item in roles)
            {
                yield return item;
            }
        }

        public RoleDTO GetRole(int id)
        {
            RoleDTO role = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataReader reader = null;
                try
                { 
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "Role_Get";
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
                    int _id = (int)reader["Id"];
                    string name = (string)reader["Name"];
                    role = new RoleDTO(_id, name);
                }
            }
            return role;
        }

        public bool Delete(string name)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = "Role_Delete";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Name", name);
                    connection.Open();
                    var result = command.ExecuteNonQuery();
                    if (result != 0) return false;
                }
            }
            catch(Exception e)
            {
                logger.Error(e.Message);
            }
            return true;
        }
    }
}
