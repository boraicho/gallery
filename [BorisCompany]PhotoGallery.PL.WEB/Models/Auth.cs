namespace WEB.Models
{
    using _BorisCompany_PhotoGallery.Interfaces.BLL;
    using _BorisCompany_PhotoGallery.BLL.PhotoLogic;
    using log4net;

    public class Auth
    {
        public static IUserBLL us = new UserLogic();

        public static bool CanLogin(string login, string password)
        {
            return us.SearchUser(login, password);
        }
    }
}