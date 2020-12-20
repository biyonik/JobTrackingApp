using System.Collections.Generic;
using JobTrackingApp.DataAccess.Concrete.EfCore.Contexts;
using JobTrackingApp.DataAccess.Interfaces;
using JobTrackingApp.Entities.Concrete;

namespace JobTrackingApp.DataAccess.Concrete.EfCore.Repositories
{
    public class EfAppUserRepository: EfGenericRepository<AppUser, JobTrackingContext>, IAppUserDAL
    {
        public List<AppUser> GetNonAdminUsers()
        {
            using var context = new JobTrackingContext();
            List<AppUser> users = new List<AppUser>();
            return users;
        }
    }
}