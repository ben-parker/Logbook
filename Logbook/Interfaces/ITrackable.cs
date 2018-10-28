using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logbook.Interfaces
{
    public interface ITrackable
    {
        int Id { get; }
        string Description { get; }
        bool Remind { get; }
        bool Repeat { get; }
        bool MarkDone { get; }
        DateTime? DueDate { get; }
    }
}
