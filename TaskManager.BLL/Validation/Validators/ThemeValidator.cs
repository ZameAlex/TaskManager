﻿using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using TaskManager.DLL.Models;

namespace TaskManager.BLL.Validation.Validators
{
    public class ThemeValidator : AbstractValidator<Theme>
    {
        public ThemeValidator()
        {
        }
    }
}