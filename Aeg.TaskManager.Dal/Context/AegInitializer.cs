using System.Data.Entity;
namespace Aeg.TaskManager.Dal.Context
{
    public class AegInitializer : DropCreateDatabaseIfModelChanges<AegDbContext>
    {
        public AegInitializer()
        {

        }
    }
}
