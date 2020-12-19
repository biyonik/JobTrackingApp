using System.Collections.Generic;
using JobTrackingApp.Entities.Concrete;

namespace JobTrackingApp.DataAccess.Interfaces
{
    public interface ITaskDAL: IGenericDAL<Task>
    {
        List<Task> GetAllIncompleteTasksWithPriority();
    }
}