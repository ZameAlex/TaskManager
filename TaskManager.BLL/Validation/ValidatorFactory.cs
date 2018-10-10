using FluentValidation;
using TaskManager.DLL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using TaskManager.BLL.Validation.Validators;

namespace TaskManager.BLL.Validation
{
    public class ValidatorFactory : IValidatorFactory
    {
        public IValidator<T> GetValidator<T>()
        {
            Type type = typeof(T);
            if (type == typeof(CalendarDay))
                return new CalendarDayValidator() as IValidator<T>;
            else if (type == typeof(ConcreteTask))
                return new ConcreteTaskValidator() as IValidator<T>;
            else if (type == typeof(DescriptiveEntity))
                return new DescriptiveEntityValidator() as IValidator<T>;
            else if (type == typeof(GlobalTask))
                return new GlobalTaskValidator() as IValidator<T>;
            else if (type == typeof(Stage))
                return new StageValidator() as IValidator<T>;
            else if (type == typeof(Task))
                return new TaskValidator() as IValidator<T>;
            else if (type == typeof(Theme))
                return new ThemeValidator() as IValidator<T>;
            else if (type == typeof(User))
                return new UserValidator() as IValidator<T>;
            else throw new ArgumentException("Type not found in Models");

        }

        public IValidator GetValidator(Type type)
        {
            if (type == typeof(CalendarDay))
                return new CalendarDayValidator() as IValidator;
            else if (type == typeof(ConcreteTask))
                return new ConcreteTaskValidator() as IValidator;
            else if (type == typeof(DescriptiveEntity))
                return new DescriptiveEntityValidator() as IValidator;
            else if (type == typeof(GlobalTask))
                return new GlobalTaskValidator() as IValidator;
            else if (type == typeof(Stage))
                return new StageValidator() as IValidator;
            else if (type == typeof(Task))
                return new TaskValidator() as IValidator;
            else if (type == typeof(Theme))
                return new ThemeValidator() as IValidator;
            else if (type == typeof(User))
                return new UserValidator() as IValidator;
            else throw new ArgumentException("Type not found in Models");
        }
    }
}
