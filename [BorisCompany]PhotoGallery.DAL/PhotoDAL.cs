namespace _BorisCompany_PhotoGallery.DAL.DB
{
    using Interfaces.DAL;
    using System;
    using System.Collections.Generic;
    using Entites;
    using System.Data.SqlClient;
    using System.Configuration;
    using log4net;

    public class PhotoDAL : IPhotoDAL
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(PhotoDAL));
        private string connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;

        public bool ChangeName(Guid id, string name)
        {
            throw new NotImplementedException();
        }

        public bool Create(string name, byte[] photo, string contentType, Guid idUSerLoad)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    Guid id = Guid.NewGuid();
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = "Photo_Add";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Content", photo);
                    command.Parameters.AddWithValue("@DateAdded", DateTime.Now);
                    command.Parameters.AddWithValue("@IdUserLoad", idUSerLoad);
                    command.Parameters.AddWithValue("@ContentType", contentType);
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

        public bool Delete(Guid id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = "Photo_Delete";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", id);
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

        public IEnumerable<PhotoDTO> GetAllPhotoUsers(Guid idUser)
        {
            List<PhotoDTO> photos = new List<PhotoDTO>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataReader reader = null;
                try
                {
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = "User_Get_All_Photo";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Id", idUser);
                    connection.Open();
                    reader = command.ExecuteReader();
                }
                catch (Exception e)
                {
                    logger.Error(e.Message);
                }
                while (reader.Read())
                {
                    Guid id = (Guid)reader["Id"];
                    string _name = (string)reader["Name"];
                    byte[] content = (byte[])reader["Content"];
                    string contentType = (string)reader["ContentType"];
                    DateTime dateAdded = (DateTime)reader["DateAdded"];
                    int aScore = (int)reader["AScore"];
                    int allScore = (int)reader["AllScore"];
                    int cScore = (int)reader["CountUsersScore"];
                    Guid idUserLoad = (Guid)reader["IdUserLoad"];
                    PhotoDTO photo = new PhotoDTO(id, content, contentType, _name, dateAdded, aScore, allScore, cScore, idUserLoad);
                    photos.Add(photo);
                }
            }
            foreach (var item in photos)
            {
                yield return item;
            }
        }

        public PhotoDTO GetPhoto(Guid id)
        {
            PhotoDTO photo = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataReader reader = null;
                try
                {
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = "Photo_Get_By_Id";
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
                    string _name = (string)reader["Name"];
                    byte[] content = (byte[])reader["Content"];
                    string contentType = (string)reader["ContentType"];
                    DateTime dateAdded = (DateTime)reader["DateAdded"];
                    int aScore = (int)reader["AScore"];
                    int allScore = (int)reader["AllScore"];
                    int cScore = (int)reader["CountUsersScore"];
                    Guid idUserLoad = (Guid)reader["IdUserLoad"];
                    photo = new PhotoDTO(_id, content, contentType, _name, dateAdded, aScore, allScore, cScore, idUserLoad);
                }
            }
            return photo;
        }

        public IEnumerable<PhotoDTO> GetPhoto(string name)
        {
            List<PhotoDTO> photos = new List<PhotoDTO>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataReader reader = null;
                try
                {
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = "Photo_Get";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Name", name);
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
                    string _name = (string)reader["Name"];
                    byte[] content = (byte[])reader["Content"];
                    string contentType = (string)reader["ContentType"];
                    DateTime dateAdded = (DateTime)reader["DateAdded"];
                    int aScore = (int)reader["AScore"];
                    int allScore = (int)reader["AllScore"];
                    int cScore = (int)reader["CountUsersScore"];
                    Guid idUserLoad = (Guid)reader["IdUserLoad"];
                    var photo = new PhotoDTO(id, content, contentType, _name, dateAdded, aScore, allScore, cScore, idUserLoad);
                    photos.Add(photo);
                }
            }
            foreach (var item in photos)
            {
                yield return item;
            };
        }

        public IEnumerable<PhotoDTO> GetPhotoSortedByDate()
        {
            List<PhotoDTO> photos = new List<PhotoDTO>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataReader reader = null;
                try
                {
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = "Photo_Get_Sorted_By_Date";
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
                    string _name = (string)reader["Name"];
                    byte[] content = (byte[])reader["Content"];
                    string contentType = (string)reader["ContentType"];
                    DateTime dateAdded = (DateTime)reader["DateAdded"];
                    int aScore = (int)reader["AScore"];
                    int allScore = (int)reader["AllScore"];
                    int cScore = (int)reader["CountUsersScore"];
                    Guid idUserLoad = (Guid)reader["IdUserLoad"];
                    PhotoDTO photo = new PhotoDTO(id, content, contentType, _name, dateAdded, aScore, allScore, cScore, idUserLoad);
                    photos.Add(photo);
                }
            }
            foreach (var item in photos)
            {
                yield return item;
            }
        }

        public IEnumerable<PhotoDTO> GetPhotoSortedByPopular()
        {
            List<PhotoDTO> photos = new List<PhotoDTO>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataReader reader = null;
                try
                {
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = "Photo_Get_Sorted_By_Popular";
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
                    string _name = (string)reader["Name"];
                    byte[] content = (byte[])reader["Content"];
                    string contentType = (string)reader["ContentType"];
                    DateTime dateAdded = (DateTime)reader["DateAdded"];
                    int aScore = (int)reader["AScore"];
                    int allScore = (int)reader["AllScore"];
                    int cScore = (int)reader["CountUsersScore"];
                    Guid idUserLoad = (Guid)reader["IdUserLoad"];
                    PhotoDTO photo = new PhotoDTO(id, content, contentType, _name, dateAdded, aScore, allScore, cScore, idUserLoad);
                    photos.Add(photo);
                }
            }
            foreach (var item in photos)
            {
                yield return item;
            }
        }
    }
}
