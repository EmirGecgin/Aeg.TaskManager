using Aeg.TaskManager.Entity;
using System.Collections.Generic;
namespace Aeg.TaskManager.Bll.Interfaces
{
    public interface IUserBll
    {
        void AddUser(User user);
        List<User> GetAll();
        void UpdateUser(User user);
        User GetById(int Id);
        void DeleteUser(int Id);
        User GetByUsername(string username);
        List<User> GetAllUsers();

    }
}
