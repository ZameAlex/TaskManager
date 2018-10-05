using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using TaskManager.DLL.Models;

namespace TaskManager.BLL.Validation.Validators
{
    public class GlobalTaskValidator : AbstractValidator<GlobalTask>
    {
        public GlobalTaskValidator()
        {
            RuleFor(g => g.Tasks).NotEmpty();
            RuleFor(g => g.Status).NotNull();
            var validator = new DescriptiveEntityValidator();
            foreach (var rule in validator)
                AddRule(rule);
        }
    }
}