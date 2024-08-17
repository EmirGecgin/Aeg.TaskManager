using Aeg.TaskManager.Entity;
using System.Collections.Generic;
namespace Aeg.TaskManager.Dal.Interfaces
{
    public interface IUserDal
    {
        void AddUser(User user);
        List<User> GetAll();
        ///Kendim Ekledim
        void UpdateUser(User user);
        User GetById(int Id);
        void DeleteUser(int Id);
        User GetByUsername(string username);
        List<User> GetAllUsers();
    }
}
