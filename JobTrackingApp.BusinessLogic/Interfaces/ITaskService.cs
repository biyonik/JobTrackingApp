using System.Collections.Generic;
using JobTrackingApp.Entities.Concrete;
using JobTrackingSystem.BusinessLogic.Interfaces;

namespace JobTrackingApp.BusinessLogic.Interfaces
{
    public interface ITaskService: IGenericService<Task>
    {
        List<Task> GetAllIncompleteTasksWithPriority();

        List<Task> GetAllTasksWithRelatedEntities();

        Task GetByPriority(int Id);
    }
}