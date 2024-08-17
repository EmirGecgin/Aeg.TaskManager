using Aeg.TaskManager.Entity;
namespace Aeg.TaskManager.Bll.Interfaces
{
    public interface ISessionService
    {
        void SetUserSession(User user);
        int GetUserId();
        string GetUsername();
    }
}
