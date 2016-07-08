namespace _BorisCompany_PhotoGallery.Interfaces.BLL
{
    using Entites;
    using System;
    using System.Collections.Generic;

    public interface IUserScoreBLL
    {
        bool AddScore(Guid idUser, Guid id, int rating);

        IEnumerable<UserScoreDTO> GetAllPhotoScore(Guid idPhoto);

        UserScoreDTO ScoreSearch(Guid idPhoto, Guid idUser);
    }
}
