using System.Collections.Generic;
using JobTrackingApp.Entities.Interfaces;

namespace JobTrackingApp.DataAccess.Interfaces
{
    public interface IGenericDAL<T> 
        where T: class, IEntity, new()
    {
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        T Get(int Id);
        List<T> GetAll();
    }
}