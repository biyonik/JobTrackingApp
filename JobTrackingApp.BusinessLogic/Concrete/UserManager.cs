using System.Collections.Generic;
using JobTrackingApp.BusinessLogic.Interfaces;
using JobTrackingApp.DataAccess.Concrete.EfCore.Repositories;
using JobTrackingApp.Entities.Concrete;

namespace JobTrackingApp.BusinessLogic.Concrete
{
    public class UserManager: IUserService
    {
        private readonly EfUserRepository _efUserRepository;

        public UserManager()
        {
            _efUserRepository = new EfUserRepository();
        }
        
        public void Add(User entity)
        {
            _efUserRepository.Add(entity);
        }

        public void Delete(User entity)
        {
            _efUserRepository.Delete(entity);
        }

        public void Update(User entity)
        {
            _efUserRepository.Update(entity);
        }

        public User Get(int Id)
        {
            return _efUserRepository.Get(Id);
        }

        public List<User> GetAll()
        {
            return _efUserRepository.GetAll();
        }
    }
}