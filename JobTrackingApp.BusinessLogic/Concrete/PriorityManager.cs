using System.Collections.Generic;
using JobTrackingApp.BusinessLogic.Interfaces;
using JobTrackingApp.DataAccess.Concrete.EfCore.Repositories;
using JobTrackingApp.Entities.Concrete;

namespace JobTrackingApp.BusinessLogic.Concrete
{
    public class PriorityManager: IPriorityService
    {
        private readonly EfPriorityRepository _efPriorityRepository;

        public PriorityManager(EfPriorityRepository efPriorityRepository)
        {
            _efPriorityRepository = efPriorityRepository;
        }
        
        public void Add(Priority entity)
        {
            _efPriorityRepository.Add(entity);
        }

        public void Delete(Priority entity)
        {
            _efPriorityRepository.Delete(entity);
        }

        public void Update(Priority entity)
        {
            _efPriorityRepository.Update(entity);
        }

        public Priority Get(int Id)
        {
            return _efPriorityRepository.Get(Id);
        }

        public List<Priority> GetAll()
        {
            return _efPriorityRepository.GetAll();
        }
    }
}