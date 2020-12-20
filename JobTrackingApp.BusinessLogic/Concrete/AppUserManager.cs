using System.Collections.Generic;
using JobTrackingApp.BusinessLogic.Interfaces;
using JobTrackingApp.DataAccess.Interfaces;
using JobTrackingApp.Entities.Concrete;

namespace JobTrackingApp.BusinessLogic.Concrete
{
    public class AppUserManager: IAppUserService
    {
        private readonly IAppUserDAL _appUserDal;

        public AppUserManager(IAppUserDAL appUserDal)
        {
            _appUserDal = appUserDal;
        }
        public List<AppUser> GetNonAdminUsers()
        {
            return _appUserDal.GetNonAdminUsers();
        }

        public List<AppUser> GetNonAdminUsers(out int totalPageCount, string searchParam, int activePage)
        {
            return _appUserDal.GetNonAdminUsers(out totalPageCount, searchParam, activePage);
        }
    }
}