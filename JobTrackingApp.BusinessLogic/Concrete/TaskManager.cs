using System.Collections.Generic;
using JobTrackingApp.BusinessLogic.Interfaces;
using JobTrackingApp.DataAccess.Concrete.EfCore.Repositories;
using JobTrackingApp.Entities.Concrete;

namespace JobTrackingApp.BusinessLogic.Concrete
{
    public class TaskManager: ITaskService
    {
        private readonly EfTaskRepository _efUserRepository;

        public TaskManager()
        {
            _efUserRepository = new EfTaskRepository();
        }
        
        public void Add(Task entity)
        {
            _efUserRepository.Add(entity);
        }

        public void Delete(Task entity)
        {
            _efUserRepository.Delete(entity);
        }

        public void Update(Task entity)
        {
            _efUserRepository.Update(entity);
        }

        public Task Get(int Id)
        {
            return _efUserRepository.Get(Id);
        }

        public List<Task> GetAll()
        {
            return _efUserRepository.GetAll();
        }
    }
}