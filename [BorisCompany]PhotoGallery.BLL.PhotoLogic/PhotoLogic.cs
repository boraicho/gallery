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

    public class PhotoLogic: IPhotoBLL
    {
        private IPhotoDAL PhotoDAL;
        private static readonly ILog logger = LogManager.GetLogger(typeof(UserLogic));

        public PhotoLogic()
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
                    PhotoDAL = new DAL.DB.PhotoDAL();
                    break;
            }
        }

        public bool ChangeName(Guid id, string name)
        {
            return PhotoDAL.ChangeName(id, name);
        }

        public bool Create(string name, byte[] photo, string contentType, Guid idUserLoad)
        {
            return PhotoDAL.Create(name, photo, contentType, idUserLoad);
        }

        public bool Delete(Guid id)
        {
            return PhotoDAL.Delete(id);
        }

        public IEnumerable<PhotoDTO> GetAllPhotoUsers(Guid idUser)
        {
            return PhotoDAL.GetAllPhotoUsers(idUser).ToArray();
        }

        public PhotoDTO GetPhoto(Guid id)
        {
            return PhotoDAL.GetPhoto(id);
        }

        public IEnumerable<PhotoDTO> GetPhoto(string name)
        {
            return PhotoDAL.GetPhoto(name).ToArray();
        }

        public IEnumerable<PhotoDTO> GetPhotoSortedByDate()
        {
            return PhotoDAL.GetPhotoSortedByDate().ToArray();
        }

        public IEnumerable<PhotoDTO> GetPhotoSortedByPopular()
        {
            return PhotoDAL.GetPhotoSortedByPopular().ToArray();
        }
    }
}
