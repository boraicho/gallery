namespace _BorisCompany_PhotoGallery.DAL.DB
{
    using Interfaces.DAL;
    using System;
    using System.Collections.Generic;
    using Entites;
    using System.Configuration;
    using System.Data.SqlClient;
    using log4net;

    public class UserScoreDAL : IUserScoreDAL
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
        private static readonly ILog logger = LogManager.GetLogger(typeof(UserScoreDAL));

        public bool AddScore(Guid idUser, Guid idPhoto, int rating)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = "Score_Add";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IdUser", idUser);
                    command.Parameters.AddWithValue("@IdPhoto", idPhoto);
                    command.Parameters.AddWithValue("@Score", rating);
                    connection.Open();
                    var result = command.ExecuteNonQuery();
                    if (result == 0) return false;
                }
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }
            return true;
        }

        public IEnumerable<UserScoreDTO> GetAllPhotoScore(Guid idPhoto)
        {
            List<UserScoreDTO> scores = new List<UserScoreDTO>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataReader reader = null;
                try
                {
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = "Photo_Get_All_Score";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IdPhoto", idPhoto);
                    connection.Open();
                    reader = command.ExecuteReader();
                }
                catch(Exception e)
                {
                    logger.Error(e.Message);
                }
                while (reader.Read())
                {
                    Guid idUser = (Guid)reader["IdUser"];
                    Guid _idPhoto = (Guid)reader["IdPhoto"];
                    int rating = (int)reader["Score"];
                    UserScoreDTO score = new UserScoreDTO(idUser, _idPhoto, rating);
                    scores.Add(score);
                }
            }
            foreach (var item in scores)
            {
                yield return item;
            }
        }
        public UserScoreDTO ScoreSearch(Guid idPhoto, Guid idUSer)
        {
            UserScoreDTO score = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataReader reader = null;
                try
                {
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = "Score_Search";
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IdPhoto", idPhoto);
                    command.Parameters.AddWithValue("@IdUser", idUSer);
                    connection.Open();
                    reader = command.ExecuteReader();
                }
                catch (Exception e)
                {
                    logger.Error(e.Message);
                }
                while (reader.Read())
                {
                    Guid idUser = (Guid)reader["IdUser"];
                    Guid _idPhoto = (Guid)reader["IdPhoto"];
                    int rating = (int)reader["Score"];
                    score = new UserScoreDTO(idUser, _idPhoto, rating);
                }
            }
            return score;
        }
    }
}
