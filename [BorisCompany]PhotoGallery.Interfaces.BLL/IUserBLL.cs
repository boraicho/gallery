namespace _BorisCompany_PhotoGallery.Interfaces.BLL
{
    using Entites;
    using System;
    using System.Collections.Generic;

    public interface IUserBLL
    {
        IEnumerable<UserDTO> GetAllUser();

        UserDTO GetUser(string login);

        UserDTO GetUser(Guid id);

        bool Create(string login, string password);

        bool Delete(Guid id);

        bool ChangePassword(Guid id, string password);

        bool ChangeRole(string login, int role);

        bool SearchUser(string login, string password);
    }
}
