using System.Collections.Generic;
using TaskManager.DLL.DBContext;
using TaskManager.DLL.Models;
using TaskManager.Shared.Exceptions;

namespace TaskManager.DAL.Repositories
{
    public class ThemeRepository : BaseRepository<Theme>
    {
        public ThemeRepository(TaskManagerContext tmContext) : base(tmContext)
        {

        }

        public override void Update(int id, Theme entity)
        {
            var tmp = GetById(id);
            tmp.Name = entity.Name;
            tmp.Description = entity.Description;
            tmp.Tasks = entity.Tasks;
            tmContext.Themes.Update(tmp);
            base.Update(id, tmp);
        }

        public void UpdateThemeName(int id, string name)
        {
            var tmp = GetById(id);
            tmp.Name = name;
            tmContext.Themes.Update(tmp);
            base.Update(id, tmp);
        }

        public void UpdateThemeDescription(int id, string description)
        {
            var tmp = GetById(id);
            tmp.Description = description;
            tmContext.Themes.Update(tmp);
            base.Update(id, tmp);
        }

        public void UpdateThemeTasksByAddingTask(int id, Task task)
        {
            var tmp = GetById(id);
            tmp.Tasks.Add(task);
            tmContext.Themes.Update(tmp);
            base.Update(id, tmp);
        }

        public void UpdateThemeTasksByAddingTasks(int id, List<Task> tasks)
        {
            var tmp = GetById(id);
            foreach (var item in tasks)
            {
                tmp.Tasks.Add(item);
            }
            tmContext.Themes.Update(tmp);
            base.Update(id, tmp);
        }

        public void UpdateThemeTasksByDeletingTask(int id, Task task)
        {
            var tmp = GetById(id);
            if (!tmp.Tasks.Remove(task))
            {
                throw new NotFoundException($"Task with id = {task.Id} wasn't found in list \"Tasks\".");
            }
            tmContext.Themes.Update(tmp);
            base.Update(id, tmp);
        }

        public void UpdateThemeTasksByDeletingTasks(int id, List<Task> tasks)
        {
            var tmp = GetById(id);
            foreach (var item in tasks)
            {
                if (!tmp.Tasks.Remove(item))
                {
                    throw new NotFoundException($"Task with id = {item.Id} wasn't found in list \"Tasks\".");
                }
            }
            tmContext.Themes.Update(tmp);
            base.Update(id, tmp);
        }
    }
}