using System.Collections.Generic;
using JobTrackingApp.BusinessLogic.Interfaces;
using JobTrackingApp.DataAccess.Concrete.EfCore.Repositories;
using JobTrackingApp.Entities.Concrete;

namespace JobTrackingApp.BusinessLogic.Concrete
{
    public class JobManager: IJobService
    {
        private readonly EfJobRepository _efUserRepository;

        public JobManager()
        {
            _efUserRepository = new EfJobRepository();
        }
        
        public void Add(Job entity)
        {
            _efUserRepository.Add(entity);
        }

        public void Delete(Job entity)
        {
            _efUserRepository.Delete(entity);
        }

        public void Update(Job entity)
        {
            _efUserRepository.Update(entity);
        }

        public Job Get(int Id)
        {
            return _efUserRepository.Get(Id);
        }

        public List<Job> GetAll()
        {
            return _efUserRepository.GetAll();
        }
    }
}