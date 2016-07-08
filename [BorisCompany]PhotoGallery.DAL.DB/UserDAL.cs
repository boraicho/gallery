namespace _BorisCompany_PhotoGallery.DAL.DB
{
    using Interfaces.DAL;
    using System;
    using System.Collections.Generic;
    using Entites;
    using System.Configuration;
    using System.Data.SqlClient;

    public class UserDAL : IUserDAL
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;

        public bool ChangePassword(Guid id, byte[] password)
        {
            throw new NotImplementedException();
        }

        public bool Create(string login, byte[] password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                Guid id = Guid.NewGuid();
                SqlCommand command = connection.CreateCommand();
                command.CommandText = $"INSERT INTO dbo.Users (Id, Login, ) VALUES (@Id, @Name, @Date_of_birth)";
                command.Parameters.AddWithValue("@Id", id);
                command.Parameters.AddWithValue("@Name", Name);
                command.Parameters.AddWithValue("@Date_of_birth", DateOfBirth);
                connection.Open();
                var result = command.ExecuteNonQuery();
            }
            return true;
        }

        public bool Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserDTO> GetAllUser()
        {
            throw new NotImplementedException();
        }

        public UserDTO GetUser(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
