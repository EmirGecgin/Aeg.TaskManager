using Aeg.TaskManager.Entity;
namespace Aeg.TaskManager.Bll.Interfaces
{
    public interface IAuthenticationBll
    {
        User Login(string username, string password);
        void Logout();
    }
}
