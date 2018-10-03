using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using TaskManager.DLL.Models;
using System.Text.RegularExpressions;

namespace TaskManager.BLL.Validation.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.Password).MinimumLength(6).
                Matches(@"/.[!,@,#,$,%,^,&,*,?,_,~,-,£,(,)]/", RegexOptions.ECMAScript).
                Matches(@"/\d+/", RegexOptions.ECMAScript).
                Matches(@"/[a-z]/", RegexOptions.ECMAScript).
                Matches(@"/[A-Z]/", RegexOptions.ECMAScript);
            RuleFor(u => u.Login).Matches(@"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
            + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
            + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$", RegexOptions.IgnoreCase);
            RuleFor(u => u.Nickname).MinimumLength(5).MaximumLength(15);
        }
    }
}