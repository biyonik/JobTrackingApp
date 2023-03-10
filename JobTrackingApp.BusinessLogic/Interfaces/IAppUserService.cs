using System.Collections.Generic;
using JobTrackingApp.Entities.Concrete;

namespace JobTrackingApp.BusinessLogic.Interfaces
{
    public interface IAppUserService
    {
        List<AppUser> GetNonAdminUsers();
        List<AppUser> GetNonAdminUsers(out int totalPageCount, string searchParam, int activePage);
    }
}