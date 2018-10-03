using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using TaskManager.DLL.Models;

namespace TaskManager.BLL.Validation.Validators
{
    public class CalendarDayValidator : AbstractValidator<CalendarDay>
    {
        public CalendarDayValidator()
        {
            RuleFor(c => c.Date < DateTime.Now.AddYears(2));
            RuleFor(c => c.FreeTime.Ticks <= TimeSpan.TicksPerDay);
            RuleFor(c => c.Tasks).NotEmpty();
        }
    }
}