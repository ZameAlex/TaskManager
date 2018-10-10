using TaskManager.DLL.Models;
using TaskManager.Shared.DTOs;

namespace TaskManager.BLL.Interfaces
{
    public interface IMapper
    {
        CalendarDayDTO MapCalendarDay(CalendarDay value);
        CalendarDay MapCalendarDay(CalendarDayDTO value);

        ConcreteTaskDTO MapConcreteTask(ConcreteTask value);
        ConcreteTask MapConcreteTask(ConcreteTaskDTO value);

        GlobalTaskDTO MapGlobalTask(GlobalTask value);
        GlobalTask MapGlobalTask(GlobalTaskDTO value);

        StageDTO MapStage(Stage value);
        Stage MapStage(StageDTO value);

        ThemeDTO MapTheme(Theme value);
        Theme MapTheme(ThemeDTO value);

        UserDTO MapUser(User value);
        User MapUser(UserDTO value);
    }
}