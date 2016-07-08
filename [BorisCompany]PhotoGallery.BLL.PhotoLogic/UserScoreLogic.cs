namespace _BorisCompany_PhotoGallery.BLL.PhotoLogic
{
    using Interfaces.BLL;
    using Interfaces.DAL;
    using System;
    using System.Configuration;
    using System.Collections.Generic;
    using Entites;
    using System.Linq;
    using log4net;

    public class UserScoreLogic: IUserScoreBLL
    {
        private IUserScoreDAL UserScoreDAL;
        private static readonly ILog logger = LogManager.GetLogger(typeof(UserLogic));

        public UserScoreLogic()
        {
            string mode = null;

            try
            {
                mode = ConfigurationManager.AppSettings["DataMode"];
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }
            switch (mode)
            {
                case "DB":
                    UserScoreDAL = new DAL.DB.UserScoreDAL();
                    break;
            }
        }

        public bool AddScore(Guid idUser, Guid idPhoto, int rating)
        {
            return UserScoreDAL.AddScore(idUser, idPhoto, rating);
        }

        public IEnumerable<UserScoreDTO> GetAllPhotoScore(Guid idPhoto)
        {
            return UserScoreDAL.GetAllPhotoScore(idPhoto).ToArray();
        }

        public UserScoreDTO ScoreSearch(Guid idPhoto, Guid idUser)
        {
            return UserScoreDAL.ScoreSearch(idPhoto, idUser);
        }
    }
}
