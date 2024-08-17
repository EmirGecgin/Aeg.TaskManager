using Aeg.TaskManager.Dal.Context;
using Aeg.TaskManager.Dal.Interfaces;
using Aeg.TaskManager.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace Aeg.TaskManager.Dal.Implementations
{
    public class UserDal : IUserDal
    {
        private AegDbContext _context { get; set; }

        public UserDal()
        {
            _context = new AegDbContext();
        }
        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }
        public User GetById(int Id)
        {
            return _context.Users.FirstOrDefault(x => x.Id == Id);
        }
        public void UpdateUser(User user)
        {
            var userToUpdate = _context.Users.FirstOrDefault(x => x.Id == user.Id);
            if (userToUpdate != null)
            {
                userToUpdate.Username = user.Username;
                userToUpdate.NameSurname = user.NameSurname;
                userToUpdate.Email = user.Email;

                _context.SaveChanges();

                var currentUserId = (int?)HttpContext.Current.Session["UserId"];
                if (currentUserId == user.Id)
                {
                    HttpContext.Current.Session["Username"] = user.Username;
                }
            }
        }
        public void DeleteUser(int Id) 
        {
            var userTasks = _context.UserTasks.Where(ut => ut.UserId == Id).ToList();
            _context.UserTasks.RemoveRange(userTasks);

            var userToDelete = _context.Users.FirstOrDefault(x => x.Id == Id);
            if (userToDelete != null)
            {
                _context.Users.Remove(userToDelete);
                _context.SaveChanges();
            }
        }
        public User GetByUsername(string username)
        {
            return _context.Users.Where(x => x.Username == username).FirstOrDefault();
        }
        public List<User> GetAllUsers()
        {
            return _context.Users.Where(x=>x.Username!="supervisor").ToList();
        }

    }
}
