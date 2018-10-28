using Logbook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logbook.Interfaces
{
    public interface IDoneService
    {
        IEnumerable<Done> GetWeek();
        IEnumerable<Done> GetUpcoming(DateTime until);
        IEnumerable<Done> GetRecentlyCompleted(DateTime since);
        Done GetMostRecentlyCompleted(int trackedId);
    }
}
