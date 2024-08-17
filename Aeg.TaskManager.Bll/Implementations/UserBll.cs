using Aeg.TaskManager.Bll.Helpers;
using Aeg.TaskManager.Bll.Interfaces;
using Aeg.TaskManager.Dal.Implementations;
using Aeg.TaskManager.Dal.Interfaces;
using Aeg.TaskManager.Entity;
using System.Collections.Generic;

namespace Aeg.TaskManager.Bll.Implementations
{
    public class UserBll : IUserBll
    {
        private IUserDal _userDal { get; set; }
        private ISessionService _sessionService { get; set; }

        public UserBll()
        {
            _userDal = new UserDal();
            _sessionService = new SessionService();
        }
        public void AddUser(User user)
        {
            user.Password = HashHelper.ComputeMD5Hash(user.Password);
            _userDal.AddUser(user);
        }

        public List<User> GetAll()
        {
            return _userDal.GetAll();
        }
        public User GetById(int Id)
        {
            return _userDal.GetById(Id);
        }
        public void UpdateUser(User user)
        {
            user.Password = HashHelper.ComputeMD5Hash(user.Password);
            _userDal.UpdateUser(user);
            

        }
        public void DeleteUser(int Id)
        {
            _userDal.DeleteUser(Id);
        }
        public User GetByUsername(string username)
        {
            return _userDal.GetByUsername(username);
        }
        public List<User> GetAllUsers()
        {
            return _userDal.GetAllUsers();
        }
    }
}
