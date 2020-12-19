using System.Collections.Generic;
using JobTrackingApp.BusinessLogic.Interfaces;
using JobTrackingApp.DataAccess.Concrete.EfCore.Repositories;
using JobTrackingApp.DataAccess.Interfaces;
using JobTrackingApp.Entities.Concrete;

namespace JobTrackingApp.BusinessLogic.Concrete
{
    public class PriorityManager: IPriorityService
    {
        private readonly IPriorityDAL _priorityDal;

        public PriorityManager(IPriorityDAL priorityDal)
        {
            _priorityDal = priorityDal;
        }
        
        public void Add(Priority entity)
        {
            _priorityDal.Add(entity);
        }

        public void Delete(Priority entity)
        {
            _priorityDal.Delete(entity);
        }

        public void Update(Priority entity)
        {
            _priorityDal.Update(entity);
        }

        public Priority Get(int Id)
        {
            return _priorityDal.Get(Id);
        }

        public List<Priority> GetAll()
        {
            return _priorityDal.GetAll();
        }
    }
}