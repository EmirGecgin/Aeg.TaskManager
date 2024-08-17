using Aeg.TaskManager.Common.Enums;
using Aeg.TaskManager.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
namespace Aeg.TaskManager.Bll.Interfaces
{
    public interface IUserTaskBll
    {
        void AddUserTask(UserTask userTask);
        void UpdateUserTask(UserTask userTask);
        void DeleteUserTask(Expression<Func<UserTask, bool>> predicate);
        List<UserTask> GetAll();
        void UpdateUserTaskStatus(int Id, UserTaskStatus UserTaskStatus);
        List<UserTask> Gets(Expression<Func<UserTask, bool>> predicate);
        UserTask Get(Expression<Func<UserTask, bool>> predicate);
        List<UserTask> GetCurrentUserTasks();
    }
}
