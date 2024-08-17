using Aeg.TaskManager.Common.Enums;
using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace Aeg.TaskManager.Entity
{
    public class UserTask : BaseEntity
    {
        public string TaskName { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public UserTaskStatus UserTaskStatus { get; set; }
        [ForeignKey("User")]
        public int? UserId { get; set; }//? işareti kullanılabilir.
        public User User { get; set; }
    }
}
