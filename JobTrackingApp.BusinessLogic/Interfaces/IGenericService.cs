using System.Collections.Generic;
using JobTrackingApp.Entities.Interfaces;

namespace JobTrackingSystem.BusinessLogic.Interfaces
{
    public interface IGenericService<TEntity> where TEntity: class, IEntity, new()
    {
        void Add(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entity);
        TEntity Get(int Id);
        List<TEntity> GetAll();
    }
}