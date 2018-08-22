using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager.Shared.Enums
{
    /// <summary>
    /// Represents day of week for repeating task
    /// </summary>
    public enum Frequency
    {
        Monday = 1,
        Tuesday = 2,
        Wednesday = 4,
        Thurthday = 8,
        Friday = 16,
        Saturday = 32,
        Sunday = 64
    }
}
