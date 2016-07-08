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

    public class UserLogic : IUserBLL
    {
        private IUserDAL UserDAL;
        private static readonly ILog logger = LogManager.GetLogger(typeof(UserLogic));

        public UserLogic()
        {
            string mode = null;

            try
            {
                 mode = ConfigurationManager.AppSettings["DataMode"];
            }
            catch(Exception e)
            {
                logger.Error(e.Message);
            }
            switch (mode)
            {
                case "DB":
                    UserDAL = new DAL.DB.UserDAL();
                    break;
            }
        }

        public bool ChangePassword(Guid id, string password)
        {
            return UserDAL.ChangePassword(id, password);
        }

        public bool ChangeRole(string login, int role)
        {
            return UserDAL.ChangeRole(login, role);
        }

        public bool Create(string login, string password)
        {
            return UserDAL.Create(login, password);
        }

        public bool Delete(Guid id)
        {
            return UserDAL.Delete(id);
        }

        public IEnumerable<UserDTO> GetAllUser()
        {
            return UserDAL.GetAllUser().ToArray();
        }

        public UserDTO GetUser(string login)
        {
            return UserDAL.GetUser(login);
        }

        public UserDTO GetUser(Guid id)
        {
            return UserDAL.GetUser(id);
        }

        public bool SearchUser(string login, string password)
        {
            return UserDAL.SearchUser(login, password);
        }
    }
}
