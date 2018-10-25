using System;
using System.Collections.Generic;
using TaskManager.DLL.Models;
using TaskManager.Shared.Enums;

namespace TaskManager.DLL.Interfaces
{
    public interface IConcreteTaskRepository
    {
        void UpdateConcreteTaskEstimation(int id, TimeSpan estimation);

        void UpdateConcreteTaskRequirement(int id, bool requirement);

        void UpdateConcreteTaskStartTime(int id, DateTime startTime);

        void UpdateConcreteTaskFrequency(int id, Frequency frequency);

        void UpdateConcreteTaskDaysByAddingDay(int id, CalendarDay day);

        void UpdateConcreteTaskDaysByAddingDays(int id, List<CalendarDay> days);

        void UpdateConcreteTaskDaysByDeletingDay(int id, CalendarDay day);

        void UpdateConcreteTaskDaysByDeletingDays(int id, List<CalendarDay> days);

        void UpdateConcreteTaskStagesByAddingStage(int id, Stage stage);

        void UpdateConcreteTaskStagesByAddingStages(int id, List<Stage> stages);

        void UpdateConcreteTaskStagesByDeletingStage(int id, Stage stage);

        void UpdateConcreteTaskStagesByDeletingStages(int id, List<Stage> stages);
    }
}