using System.Collections.Generic;
using System.Linq;
using TaskManager.DLL.Interfaces;
using TaskManager.DLL.DBContext;
using TaskManager.DLL.Models;

namespace TaskManager.DLL.Repositories
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : Entity
    {
        protected readonly TaskManagerContext tmContext;

        public BaseRepository(TaskManagerContext context)
        {
            tmContext = context;
        }

        public virtual int Create(TEntity entity)
        {
            tmContext.SetOf<TEntity>().Add(entity);
            tmContext.SaveChanges();
            return entity.Id;
        }

        public virtual void Delete(TEntity entity)
        {
            tmContext.SetOf<TEntity>().Remove(entity);
            tmContext.SaveChanges();
        }

        public virtual void DeleteById(int id)
        {
            tmContext.SetOf<TEntity>().Remove(tmContext.SetOf<TEntity>().Find(id));
            tmContext.SaveChanges();
        }

        public virtual List<TEntity> GetAll()
        {
            return tmContext.SetOf<TEntity>().ToList();
        }

        public virtual TEntity GetById(int id)
        {
            return tmContext.SetOf<TEntity>().Find(id);
        }

        public virtual void Update(int id, TEntity entity)
        {
            tmContext.SaveChanges();
        }
    }
}