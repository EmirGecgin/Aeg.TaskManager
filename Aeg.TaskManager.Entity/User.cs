using System.Collections.Generic;
namespace Aeg.TaskManager.Entity
{
    public class User:BaseEntity
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string NameSurname { get; set; }
        public IEnumerable<UserTask> UserTasks { get; set; }
    }
}
