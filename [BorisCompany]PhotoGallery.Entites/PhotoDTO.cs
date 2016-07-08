namespace _BorisCompany_PhotoGallery.Entites
{
    using System;

    public class PhotoDTO
    {
        private Guid id;
        private string name;
        private byte[] photo;
        private DateTime dateAdded;
        private int aScore;
        private int allScore;
        private int countUsersScore;
        private Guid idUserLoad;

        public string ContentType { get; set; }

        public Guid Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    name = value;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
        }

        public DateTime DateAdded
        {
            get
            {
                return dateAdded;
            }
            set
            {
                if (value > DateTime.Now)
                {
                    throw new Exception();
                }
                else
                {
                    dateAdded = value;
                }
            }
        }

        public byte[] Photo
        {
            get { return photo; }
            set { photo = value; }
        }

        public int AverageScore
        {
            get { return aScore; }
            set { aScore = value; }
        }

        public int AllScore
        {
            get { return allScore; }
            set { allScore = value; }
        }

        public int CountUsersScore
        {
            get { return countUsersScore; }
            set { countUsersScore = value; }
        }

        public Guid IdUserLoad
        {
            get{ return idUserLoad; }
            set{ idUserLoad = value; }
        }

        public PhotoDTO(Guid id, byte[] photo,string contentType, string name, DateTime dateAdded, int aScore, int allScore, int cScore, Guid idUserLoad)
        {
            Id = id;
            Photo = photo;
            Name = name;
            DateAdded = dateAdded;
            AverageScore = aScore;
            AllScore = allScore;
            CountUsersScore = countUsersScore;
            IdUserLoad = idUserLoad;
            ContentType = contentType;
        }
    }
}
