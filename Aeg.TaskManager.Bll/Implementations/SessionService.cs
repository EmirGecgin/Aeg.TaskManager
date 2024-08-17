using Aeg.TaskManager.Bll.Interfaces;
using Aeg.TaskManager.Dal.Implementations;
using Aeg.TaskManager.Dal.Interfaces;
using Aeg.TaskManager.Entity;
using System.Web;

namespace Aeg.TaskManager.Bll.Implementations
{
    public class SessionService : ISessionService
    {
        private IUserDal _userDal { get; set; }
        public SessionService()
        {
            _userDal = new UserDal();
        }
        public void SetUserSession(User user)
        {
            HttpContext.Current.Session["UserId"] = user.Id;
            HttpContext.Current.Session["Username"] = user.Username;
        }

        public int GetUserId()
        {
            return (int)HttpContext.Current.Session["UserId"];
        }

        public string GetUsername()
        {
            return HttpContext.Current.Session["Username"]?.ToString();
        }
    }
}
