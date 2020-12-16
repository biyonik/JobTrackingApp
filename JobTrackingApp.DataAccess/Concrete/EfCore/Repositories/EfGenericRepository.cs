using System.Collections.Generic;
using System.Linq;
using JobTrackingApp.DataAccess.Interfaces;
using JobTrackingApp.Entities.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JobTrackingApp.DataAccess.Concrete.EfCore.Repositories
{
    public class EfGenericRepository<TEntity, TContext>: IGenericDAL<TEntity> 
        where TEntity : class, IEntity, new()
        where TContext: DbContext, new()
    {
        private readonly TContext _context;

        public EfGenericRepository()
        {
            _context = new TContext();
        }
        
        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public TEntity Get(int Id)
        {
            return _context.Set<TEntity>().Find(Id);
        }

        public List<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }
    }
}