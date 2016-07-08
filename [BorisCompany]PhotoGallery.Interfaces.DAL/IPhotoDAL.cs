namespace _BorisCompany_PhotoGallery.Interfaces.DAL
{
    using Entites;
    using System;
    using System.Collections.Generic;

    public interface IPhotoDAL
    {
        IEnumerable<PhotoDTO> GetAllPhotoUsers(Guid idUser);

        IEnumerable<PhotoDTO> GetPhotoSortedByDate();

        IEnumerable<PhotoDTO> GetPhotoSortedByPopular();

        IEnumerable<PhotoDTO> GetPhoto(string name);

        PhotoDTO GetPhoto(Guid id);

        bool Create(string name, byte[] photo, string contentType, Guid idUserLoad);

        bool Delete(Guid id);

        bool ChangeName(Guid id, string name);
    }
}
