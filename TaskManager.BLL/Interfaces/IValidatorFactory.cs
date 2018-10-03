using System;
using System.Collections.Generic;
using System.Text;
using TaskManager.DLL.Models;
using FluentValidation;

namespace TaskManager.BLL.Interfaces
{
    public interface IValidatorFactory
    {
        AbstractValidator<CalendarDay> CalendarDayValidator();
        AbstractValidator<ConcreteTask> ConcreteTaskValidator();
        AbstractValidator<DescriptiveEntity> DescriptiveEntityValidator();
        AbstractValidator<GlobalTask> GlobalTaskValidator();
        AbstractValidator<Stage> StageValidator();
        AbstractValidator<Task> TaskValidator();
        AbstractValidator<Theme> ThemeValidator();
        AbstractValidator<User> UserValidator();
    }
}
