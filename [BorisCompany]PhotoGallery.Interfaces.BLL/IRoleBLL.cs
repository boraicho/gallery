namespace _BorisCompany_PhotoGallery.Interfaces.BLL
{
    using Entites;
    using System.Collections.Generic;

    public interface IRoleBLL
    {
        IEnumerable<RoleDTO> GetAll();

        bool AddRole(string name);

        bool Delete(string name);

        RoleDTO GetRole(int id);
    }
}
