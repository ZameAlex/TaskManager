using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using TaskManager.DLL.Models;

namespace TaskManager.BLL.Validation.Validators
{
    public class TaskValidator : AbstractValidator<DLL.Models.Task>
    {
        public TaskValidator()
        {
            var validator = new DescriptiveEntityValidator();
            foreach (var rule in validator)
                AddRule(rule);
        }
    }
}