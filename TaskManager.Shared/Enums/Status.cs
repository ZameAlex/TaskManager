using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace TaskManager.Shared.Enums
{
    /// <summary>
    /// Enum using for task status
    /// </summary>
    public enum Status
    {
        [Description("Not started")]
        NotStarted,
        [Description("In progress")]
        InProgress,
        [Description("Done")]
        Done
    }
}
