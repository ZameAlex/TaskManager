using System.Collections.Generic;
using System.Linq;
using TaskManager.DAL.Interfaces;
using TaskManager.DLL.DBContext;
using TaskManager.DLL.Models;

namespace TaskManager.DAL.Repositories
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : Entity
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

        public virtual List<TEntity> Get()
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