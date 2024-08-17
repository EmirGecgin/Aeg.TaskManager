using Aeg.TaskManager.Common.Enums;
using Aeg.TaskManager.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
namespace Aeg.TaskManager.Dal.Interfaces
{
    public interface IUserTaskDal
    {
        void AddUserTask(UserTask userTask);
        void UpdateUserTask(UserTask userTask);
        void DeleteUserTask(Expression<Func<UserTask, bool>> predicate);
        List<UserTask> GetAll();
        void UpdateUserTaskStatus(int Id, UserTaskStatus UserTaskStatus);
        List<UserTask> Gets(Expression<Func<UserTask,bool>> predicate);
        UserTask Get(Expression<Func<UserTask,bool>> predicate);
    }
}
