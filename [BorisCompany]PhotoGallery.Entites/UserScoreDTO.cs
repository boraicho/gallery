namespace _BorisCompany_PhotoGallery.Entites
{
    using System;

    public class UserScoreDTO
    {
        public Guid IdUser { get; set; }

        public Guid IdPhoto { get; set; }

        public int Score { get; set; }

        public UserScoreDTO(Guid idUser, Guid idPhoto, int rating)
        {
            IdUser = idUser;
            IdPhoto = idPhoto;
            Score = rating;
        }
    }
}
