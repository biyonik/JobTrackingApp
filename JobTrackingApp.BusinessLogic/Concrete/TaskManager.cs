using System.Collections.Generic;
using JobTrackingApp.BusinessLogic.Interfaces;
using JobTrackingApp.DataAccess.Concrete.EfCore.Repositories;
using JobTrackingApp.DataAccess.Interfaces;
using JobTrackingApp.Entities.Concrete;

namespace JobTrackingApp.BusinessLogic.Concrete
{
    public class TaskManager: ITaskService
    {
        private readonly ITaskDAL _taskDal;

        public TaskManager(ITaskDAL taskDal)
        {
            _taskDal = taskDal;
        }
        
        public void Add(Task entity)
        {
            _taskDal.Add(entity);
        }

        public void Delete(Task entity)
        {
            _taskDal.Delete(entity);
        }

        public void Update(Task entity)
        {
            _taskDal.Update(entity);
        }

        public Task Get(int Id)
        {
            return _taskDal.Get(Id);
        }

        public List<Task> GetAll()
        {
            return _taskDal.GetAll();
        }

        public List<Task> GetAllIncompleteTasksWithPriority()
        {
            return _taskDal.GetAllIncompleteTasksWithPriority();
        }
    }
}