using System.Collections.Generic;

namespace TaskManager.BLL.Interfaces
{
    public interface IService<DEntity>
    {
        List<DEntity> GetAll();

        DEntity GetById(int id);

        int Create(DEntity entity);

        void Update(int id, DEntity entity);

        void Delete(DEntity entity);

        void DeleteById(int id);
    }
}