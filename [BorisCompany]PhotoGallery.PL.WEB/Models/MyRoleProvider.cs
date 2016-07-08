namespace WEB.Models
{
    using System;
    using System.Web.Security;
    using _BorisCompany_PhotoGallery.Interfaces.BLL;
    using _BorisCompany_PhotoGallery.BLL.PhotoLogic;
    using _BorisCompany_PhotoGallery.Entites;
    using log4net;

    public class MyRoleProvider : RoleProvider
    {
        private static IUserBLL ur = new UserLogic();
        private static IRoleBLL rl = new RoleLogic();

        public override bool IsUserInRole(string login, string role)
        {
            UserDTO user = ur.GetUser(login);
            RoleDTO _role = rl.GetRole(user.Role);
            if (_role.Name != null && _role.Name == role)
            {
                return true;
            }
            return false;
        }

        public override string[] GetRolesForUser(string login)
        {
            string[] role = new string[] { };

            UserDTO user = ur.GetUser(login);
            RoleDTO _role = rl.GetRole(user.Role);
            if (_role.Name != null)
            {
                role = new string[] { _role.Name };
            }
            else
            {
                role = new string[] { };
            }
            return role;
        }

        #region Not implement
        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}