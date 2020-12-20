using System.Collections.Generic;
using JobTrackingApp.Entities.Concrete;

namespace JobTrackingApp.DataAccess.Interfaces
{
    public interface IAppUserDAL
    {
        List<AppUser> GetNonAdminUsers();
        List<AppUser> GetNonAdminUsers(out int totalPageCount, string searchParam, int activePage);
        
    }
}