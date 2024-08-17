using Aeg.TaskManager.Common.Enums;
using Aeg.TaskManager.Dal.Context;
using Aeg.TaskManager.Dal.Interfaces;
using Aeg.TaskManager.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
namespace Aeg.TaskManager.Dal.Implementations
{
    public class UserTaskDal : IUserTaskDal
    {
        private AegDbContext _context { get; set; }
        public UserTaskDal()
        {
            _context = new AegDbContext();
        }
        public void AddUserTask(UserTask userTask)
        {
            _context.UserTasks.Add(userTask);
            _context.SaveChanges();
        }

        public void DeleteUserTask(Expression<Func<UserTask, bool>> predicate)
        {
            var userTaskToDelete = _context.UserTasks.FirstOrDefault(predicate);
            if (userTaskToDelete != null)
            {
                _context.UserTasks.Remove(userTaskToDelete);
                _context.SaveChanges();
            }
        }

        public UserTask Get(Expression<Func<UserTask, bool>> predicate)
        {
            return _context.UserTasks.FirstOrDefault(predicate);
        }

        public List<UserTask> GetAll()
        {
            return _context.UserTasks.ToList();
        }

        public List<UserTask> Gets(Expression<Func<UserTask, bool>> predicate)
        {
            return _context.UserTasks.Where(predicate).ToList();
        }

        public void UpdateUserTask(UserTask userTask)
        {
            var userTaskToUpdate = _context.UserTasks.FirstOrDefault(x => x.Id == userTask.Id);
            userTaskToUpdate.TaskName = userTask.TaskName;
            userTaskToUpdate.Description = userTask.Description;
            userTaskToUpdate.StartDate = userTask.StartDate;
            userTaskToUpdate.EndDate = userTask.EndDate;
            userTaskToUpdate.UserTaskStatus = userTask.UserTaskStatus;
            userTaskToUpdate.UserId = userTask.UserId;
            //user güncelleme
            _context.SaveChanges();
        }

        public void UpdateUserTaskStatus(int Id, UserTaskStatus status)
        {
            var task = _context.UserTasks.FirstOrDefault(t => t.Id == Id);
            if (task != null)
            {
                task.UserTaskStatus = (Aeg.TaskManager.Common.Enums.UserTaskStatus)(int)status;
                _context.SaveChanges();
            }
        }
    }
}
