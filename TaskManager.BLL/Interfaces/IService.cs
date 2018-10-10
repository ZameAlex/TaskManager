using System.Collections.Generic;

namespace TaskManager.BLL.Interfaces
{
    public interface IService<TEntity>
    {
        List<TEntity> GetAll();

        TEntity GetById(int id);

        int Create(TEntity entity);

        void Update(int id, TEntity entity);

        void Delete(TEntity entity);

        void DeleteById(int id);
    }
}