namespace _BorisCompany_PhotoGallery.Interfaces.DAL
{
    using Entites;
    using System;
    using System.Collections.Generic;
    public interface IUserScoreDAL
    {
        bool AddScore(Guid idUser, Guid idPhoto, int rating);

        IEnumerable<UserScoreDTO> GetAllPhotoScore(Guid idPhoto);

        UserScoreDTO ScoreSearch(Guid idPhoto, Guid idUser);
    }
}
