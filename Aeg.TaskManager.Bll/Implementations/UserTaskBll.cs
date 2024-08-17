using Aeg.TaskManager.Bll.Interfaces;
using Aeg.TaskManager.Common.Enums;
using Aeg.TaskManager.Dal.Implementations;
using Aeg.TaskManager.Dal.Interfaces;
using Aeg.TaskManager.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
namespace Aeg.TaskManager.Bll.Implementations
{
    public class UserTaskBll : IUserTaskBll
    {
        private IUserTaskDal _userTaskDal { get; set; }
        private ISessionService _sessionService { get; set; }
        private IUserDal _userDal { get; set; }

        public UserTaskBll()
        {
            _userTaskDal = new UserTaskDal();
            _sessionService = new SessionService();
            _userDal = new UserDal();
        }
        public void AddUserTask(UserTask userTask)
        {
            userTask.UserTaskStatus = UserTaskStatus.NotStarted;
            _userTaskDal.AddUserTask(userTask);
        }

        public void DeleteUserTask(Expression<Func<UserTask, bool>> predicate)
        {
            _userTaskDal.DeleteUserTask(predicate);
        }

        public UserTask Get(Expression<Func<UserTask, bool>> predicate)
        {
            return _userTaskDal.Get(predicate);
        }

        public List<UserTask> GetAll()
        {
            return _userTaskDal.GetAll();
        }

        public List<UserTask> Gets(Expression<Func<UserTask, bool>> predicate)
        {
            return _userTaskDal.Gets(predicate);
        }

        public void UpdateUserTask(UserTask userTask)
        {
            userTask.StartDate = DateTime.Now;
            userTask.UserTaskStatus = UserTaskStatus.NotStarted;
            _userTaskDal.UpdateUserTask(userTask);
        }

        public void UpdateUserTaskStatus(int Id, UserTaskStatus status)
        {
            var entity = _userTaskDal.Get(x => x.Id == Id);
            entity.UserTaskStatus = status;
            if (status == UserTaskStatus.NotStarted || status == UserTaskStatus.InProgress )
            {
                entity.EndDate = null;
            }
            if (status == UserTaskStatus.Completed)
            {
                entity.EndDate = DateTime.Now;
            }
            if (status==UserTaskStatus.NotStarted)
            {
                entity.StartDate = DateTime.Now;
            }
            _userTaskDal.UpdateUserTask(entity);
            
        }
        public User GetCurrentUser()
        {
            var userId = _sessionService.GetUserId();
            var user = _userDal.GetById(userId);
            if (user == null)
            {
                throw new Exception("Kullanıcı bilgisi bulunamadı");
            }
            return user;
        }
        public List<UserTask> GetCurrentUserTasks()
        {
            var user = GetCurrentUser();
            return _userTaskDal.Gets(x => x.UserId == user.Id);
        }
    }
}
