using JobTrackingApp.DataAccess.Concrete.EfCore.Contexts;
using JobTrackingApp.DataAccess.Interfaces;
using JobTrackingApp.Entities.Concrete;

namespace JobTrackingApp.DataAccess.Concrete.EfCore.Repositories
{
    public class EfPriorityRepository: EfGenericRepository<Priority, JobTrackingContext>
    {
        
    }
}