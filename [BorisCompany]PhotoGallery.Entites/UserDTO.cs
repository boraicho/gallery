namespace _BorisCompany_PhotoGallery.Entites
{
    using System;

    public class UserDTO
    {
        private Guid id;
        private string login;
        private byte[] password;
        private int role;

        public Guid Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Login
        {
            get
            {
                return login;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    login = value;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
        }

        public byte[] Password
        {
            get { return password; }
            set { password = value; }
        }

        public int Role
        {
            get { return role; }
            set { role = value; }
        }

        public UserDTO(Guid id, string login, byte[] password, int role)
        {
            Id = id;
            Login = login;
            Password = password;
            Role = role;
        } 
    }
}
