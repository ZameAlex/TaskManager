using System;
using System.Collections.Generic;
using System.Text;
using TaskManager.BLL.Interfaces;
using TaskManager.BLL.Validation;
using TaskManager.DLL.Interfaces;
using TaskManager.DLL.Models;
using TaskManager.Shared.DTOs;

namespace TaskManager.BLL.Services
{
    public class CalendarDayService : BaseService<CalendarDayDTO, CalendarDay>
    {
        public CalendarDayService(IBaseRepository<CalendarDay> repository, IMapper mapper, ValidatorFactory validatorFactory) : base(repository, mapper, validatorFactory)
        {

        }
    }
}
