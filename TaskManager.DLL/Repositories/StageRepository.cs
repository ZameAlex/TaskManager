using TaskManager.DLL.DBContext;
using TaskManager.DLL.Models;

namespace TaskManager.DLL.Repositories
{
    public class StageRepository : BaseRepository<Stage>
    {
        public StageRepository(TaskManagerContext tmContext) : base(tmContext)
        {

        }

        public override void Update(int id, Stage entity)
        {
            var tmp = GetById(id);
            tmp.Name = entity.Name;
            tmp.Description = entity.Description;
            tmContext.Stages.Update(tmp);
            base.Update(id, entity);
        }

        public void UpdateStageName(int id, string name)
        {
            var tmp = GetById(id);
            tmp.Name = name;
            tmContext.Stages.Update(tmp);
            base.Update(id, tmp);
        }

        public void UpdateStageDescription(int id, string description)
        {
            var tmp = GetById(id);
            tmp.Description = description;
            tmContext.Stages.Update(tmp);
            base.Update(id, tmp);
        }
    }
}