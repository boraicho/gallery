namespace _BorisCompany_PhotoGallery.BLL.PhotoLogic
{
    using Interfaces.BLL;
    using Interfaces.DAL;
    using System.Configuration;
    using System.Collections.Generic;
    using Entites;
    using System.Linq;
    using log4net;
    using System;

    public class RoleLogic : IRoleBLL
    {
        private IRoleDAL RoleDAL;
        private static readonly ILog logger = LogManager.GetLogger(typeof(UserLogic));

        public RoleLogic()
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
                    RoleDAL = new DAL.DB.RoleDAL();
                    break;
            }
        }
        public bool AddRole(string name)
        {
            return RoleDAL.AddRole(name);
        }

        public bool Delete(string name)
        {
            return RoleDAL.Delete(name);
        }

        public IEnumerable<RoleDTO> GetAll()
        {
            return RoleDAL.GetAll().ToArray();
        }

        public RoleDTO GetRole(int id)
        {
            return RoleDAL.GetRole(id);
        }
    }
}
