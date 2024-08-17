using Aeg.TaskManager.Bll.Helpers;
using Aeg.TaskManager.Bll.Interfaces;
using Aeg.TaskManager.Dal.Implementations;
using Aeg.TaskManager.Dal.Interfaces;
using Aeg.TaskManager.Entity;
using System.Web;
namespace Aeg.TaskManager.Bll.Implementations
{
    public class AuthenticationBll : IAuthenticationBll
    {
        private IUserDal _userDal { get; set; }
        private ISessionService _sessionService { get; set; }
        public AuthenticationBll()
        {
            _userDal = new UserDal();
            _sessionService = new SessionService();
        }
        public User Login(string username, string password)
        {
            var user = _userDal.GetByUsername(username);
            if (user != null)
            {
                var hashedPassword = HashHelper.ComputeMD5Hash(password);
                if (user.Password == hashedPassword)
                {
                    _sessionService.SetUserSession(user);
                    return user;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public void Logout()
        {
            HttpContext.Current.Session.Clear();
        }
    }
}
