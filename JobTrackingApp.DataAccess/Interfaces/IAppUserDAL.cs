using System.Collections.Generic;
using JobTrackingApp.Entities.Concrete;

namespace JobTrackingApp.DataAccess.Interfaces
{
    public interface IAppUserDAL: IGenericDAL<AppUser>
    {
        List<AppUser> GetNonAdminUsers();
    }
}