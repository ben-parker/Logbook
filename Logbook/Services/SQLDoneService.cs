using Logbook.Interfaces;
using Logbook.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logbook.Services
{
    public class SQLDoneService : IDoneService
    {
        private LogbookDBContext _done;

        public SQLDoneService(LogbookDBContext done)
        {
            _done = done;
        }

        public Done GetMostRecentlyCompleted(int trackedId)
        {
            var mostRecent = _done.Done
                .Where(i => i.TrackedId == trackedId)
                .Where(i => i.CompletedDate <= DateTime.Now)
                .Include(i => i.Tracked)
                .OrderByDescending(i => i.CompletedDate)
                .FirstOrDefault();

            return mostRecent;
        }

        public IEnumerable<Done> GetRecentlyCompleted(DateTime since)
        {
            var recent = _done.Done
                .Where(i => i.CompletedDate <= DateTime.Now)
                .Where(i => i.CompletedDate >= since)
                .Include(i => i.Tracked)
                .OrderByDescending(i => i.CompletedDate)
                .ToList();

            return recent;
        }

        public IEnumerable<Done> GetUpcoming(DateTime until)
        {
            var upcoming = _done.Done
                .Where(i => i.CompletedDate == null)
                .Where(i => i.DueDate <= until)
                .Include(i => i.Tracked)
                .OrderBy(i => i.DueDate)
                .AsEnumerable();

            return upcoming;
        }

        public IEnumerable<Done> GetWeek()
        {
            var week = _done.Done
                .Where(i => i.CompletedDate == null)
                .Where(i => i.DueDate <= DateTime.Today.AddDays(6))
                .Include(i => i.Tracked)
                .AsEnumerable();

            return week;
        }
    }
}
