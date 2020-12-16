using System.Collections.Generic;
using JobTrackingApp.Entities.Concrete;

namespace JobTrackingApp.DataAccess.Interfaces
{
    public interface IJobDAL: IGenericDAL<Job>
    {
        void Add(Job job);
        void Delete(Job job);
        void Update(Job job);
        Job Get(int Id);
        List<Job> GetAll();
    }
}