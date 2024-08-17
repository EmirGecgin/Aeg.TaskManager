using Aeg.TaskManager.Entity;
using System.Data.Entity;
namespace Aeg.TaskManager.Dal.Context
{
    public class AegDbContext : DbContext
    {
        public AegDbContext() : base("AegConnString")
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<UserTask> UserTasks { get; set; }
        override protected void OnModelCreating(DbModelBuilder modelBuilder)
        {  
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<UserTask>().ToTable("UserTask");
            base.OnModelCreating(modelBuilder);
        }
    }
}
