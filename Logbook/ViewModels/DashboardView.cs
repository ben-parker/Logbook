using Logbook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logbook.ViewModels
{
    public class DashboardView
    {
        public DashboardCalendarView Calendar { get; set; }
        public IEnumerable<DashboardItem> Upcoming { get; set; }
        public IEnumerable<DashboardItem> Recent { get; set; }
    }
}
