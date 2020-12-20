using System.Collections.Generic;
using System.Linq;
using JobTrackingApp.DataAccess.Concrete.EfCore.Contexts;
using JobTrackingApp.DataAccess.Interfaces;
using JobTrackingApp.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace JobTrackingApp.DataAccess.Concrete.EfCore.Repositories
{
    public class EfTaskRepository: EfGenericRepository<Task, JobTrackingContext>, ITaskDAL
    {
        public List<Task> GetAllIncompleteTasksWithPriority()
        {
            using var context = new JobTrackingContext();
            return context.Tasks
                            .Include(task => task.Priority)
                            .Where(task => task.Status == false)
                            .OrderByDescending(task => task.CreatedDate)
                            .ToList();
        }

        public List<Task> GetAllTasksWithRelatedEntities()
        {
            using var context = new JobTrackingContext();
            return context.Tasks
                .Include(task => task.Priority)
                .Include(task => task.Reports)
                .Include(task => task.AppUser)
                .Where(task => task.Status == false)
                .OrderByDescending(task => task.CreatedDate)
                .ToList();
        }

        public Task GetByPriority(int Id)
        {
            using var context = new JobTrackingContext();
            return context.Tasks
                .Include(task => task.Priority)
                .FirstOrDefault(task => task.Status == false);
        }
    }
}