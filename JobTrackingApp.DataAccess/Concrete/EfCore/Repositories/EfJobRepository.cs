using JobTrackingApp.DataAccess.Concrete.EfCore.Contexts;
using JobTrackingApp.Entities.Concrete;

namespace JobTrackingApp.DataAccess.Concrete.EfCore.Repositories
{
    public class EfJobRepository: EfGenericRepository<Job, JobTrackingContext>
    {
    }
}