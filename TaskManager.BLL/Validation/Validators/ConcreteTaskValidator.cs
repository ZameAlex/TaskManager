using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using TaskManager.DLL.Models;

namespace TaskManager.BLL.Validation.Validators
{
    public class ConcreteTaskValidator : AbstractValidator<ConcreteTask>
    {
        public ConcreteTaskValidator()
        {
            RuleFor(t => t.Days).NotEmpty();
            RuleFor(t => t.Estimation).NotNull();
            RuleFor(t => t.Frequency).NotNull();
            RuleFor(t => t.Status).NotNull();
        }
    }
}