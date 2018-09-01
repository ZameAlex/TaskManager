using System.Collections.Generic;
using TaskManager.DLL.DBContext;
using TaskManager.DLL.Models;
using TaskManager.Shared.Exceptions;

namespace TaskManager.DLL.Repositories
{
    public class UserRepository : BaseRepository<User>
    {
        public UserRepository(TaskManagerContext tmContext) : base(tmContext)
        {

        }

        public override void Update(int id, User entity)
        {
            var tmp = GetById(id);
            tmp.Login = entity.Login;
            tmp.Password = entity.Password;
            tmp.Tasks = entity.Tasks;
            tmp.Themes = entity.Themes;
            tmContext.Users.Update(tmp);
            base.Update(id, tmp);
        }

        public void UpdateUserNickname(int id, string nickname)
        {
            var tmp = GetById(id);
            tmp.Nickname = nickname;
            tmContext.Users.Update(tmp);
            base.Update(id, tmp);
        }

        public void UpdateUserPassword(int id, string password)
        {
            var tmp = GetById(id);
            tmp.Password = password;
            tmContext.Users.Update(tmp);
            base.Update(id, tmp);
        }

        public void UpdateUserTasksByAddingTask(int id, Task task)
        {
            var tmp = GetById(id);
            tmp.Tasks.Add(task);
            tmContext.Users.Update(tmp);
            base.Update(id, tmp);
        }

        public void UpdateUserTasksByAddingTasks(int id, List<Task> tasks)
        {
            var tmp = GetById(id);
            foreach (var item in tasks)
            {
                tmp.Tasks.Add(item);
            }
            tmContext.Users.Update(tmp);
            base.Update(id, tmp);
        }

        public void UpdateUserTasksByDeletingTask(int id, Task task)
        {
            var tmp = GetById(id);
            if (!tmp.Tasks.Remove(task))
            {
                throw new NotFoundException($"Task with id = {task.Id} wasn't found in list \"Tasks\".");
            }
            tmContext.Users.Update(tmp);
            base.Update(id, tmp);
        }

        public void UpdateUserTasksByDeletingTasks(int id, List<Task> tasks)
        {
            var tmp = GetById(id);
            foreach (var item in tasks)
            {
                if (!tmp.Tasks.Remove(item))
                {
                    throw new NotFoundException($"Task with id = {item.Id} wasn't found in list \"Tasks\".");
                }
            }
            tmContext.Users.Update(tmp);
            base.Update(id, tmp);
        }

        public void UpdateUserThemesByAddingTheme(int id, Theme theme)
        {
            var tmp = GetById(id);
            tmp.Themes.Add(theme);
            tmContext.Users.Update(tmp);
            base.Update(id, tmp);
        }

        public void UpdateUserThemesByAddingThemes(int id, List<Theme> themes)
        {
            var tmp = GetById(id);
            foreach (var item in themes)
            {
                tmp.Themes.Add(item);
            }
            tmContext.Users.Update(tmp);
            base.Update(id, tmp);
        }

        public void UpdateUserThemesByDeletingTheme(int id, Theme theme)
        {
            var tmp = GetById(id);
            if (!tmp.Themes.Remove(theme))
            {
                throw new NotFoundException($"Theme with id = {theme.Id} wasn't found in list \"Themes\".");
            }
            tmContext.Users.Update(tmp);
            base.Update(id, tmp);
        }

        public void UpdateUserThemesByDeletingThemes(int id, List<Theme> themes)
        {
            var tmp = GetById(id);
            foreach (var item in themes)
            {
                if (!tmp.Themes.Remove(item))
                {
                    throw new NotFoundException($"Theme with id = {item.Id} wasn't found in list \"Themes\".");
                }
            }
            tmContext.Users.Update(tmp);
            base.Update(id, tmp);
        }
    }
}