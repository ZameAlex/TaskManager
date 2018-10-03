using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using TaskManager.DLL.Models;

namespace TaskManager.BLL.Validation.Validators
{
    public class DescriptiveEntityValidator : AbstractValidator<DescriptiveEntity>
    {
        public DescriptiveEntityValidator()
        {
            RuleFor(d => d.Description).MinimumLength(10);
            RuleFor(d => d.Name).MinimumLength(3).MaximumLength(20);
        }
    }
}