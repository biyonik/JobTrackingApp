using System.Collections.Generic;
using JobTrackingApp.Entities.Concrete;

namespace JobTrackingApp.DataAccess.Interfaces
{
    public interface IUserDAL: IGenericDAL<User>
    {
        void Add(User user);
        void Delete(User user);
        void Update(User user);
        User Get(int Id);
        List<User> GetAll();
    }
}