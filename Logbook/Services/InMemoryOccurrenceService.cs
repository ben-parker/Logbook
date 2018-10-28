using Logbook.Interfaces;
using Logbook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logbook.Services
{
    public class InMemoryOccurrenceService : IDoneService
    {
        private List<Done> _done;

        public InMemoryOccurrenceService()
        {
           
        }
        public Done GetMostRecentlyCompleted(int trackedId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Done> GetRecentlyCompleted(DateTime since)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Done> GetUpcoming(DateTime until)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Done> GetWeek()
        {
            throw new NotImplementedException();
        }
    }
}
