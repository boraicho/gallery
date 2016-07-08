namespace _BorisCompany_PhotoGallery.Interfaces.DAL
{
    using Entites;
    using System.Collections.Generic;

    public interface IRoleDAL
    {
        IEnumerable<RoleDTO> GetAll();

        bool AddRole(string name);

        bool Delete(string name);

        RoleDTO GetRole(int id);
    }
}
