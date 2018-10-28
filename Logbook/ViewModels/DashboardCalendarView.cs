using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logbook.Models;

namespace Logbook.ViewModels
{
    public class DashboardCalendarView
    {
        public DashboardCalendarView(IEnumerable<Done> week)
        {
            this.Items = new List<List<string>>();

            for (int i = 0; i < 7; i++)
            {
                this.Items.Add(new List<string>());
            }

            foreach (var item in week)
            {
                DateTime date = item.DueDate.HasValue ? item.DueDate.Value.Date : DateTime.MinValue.Date;

                if (date == DateTime.Today)
                    this.Items[0].Add(item.Tracked.Description);
                else if (date == DateTime.Today.AddDays(1))
                    this.Items[1].Add(item.Tracked.Description);
                else if (date == DateTime.Today.AddDays(2))
                    this.Items[2].Add(item.Tracked.Description);
                else if (date == DateTime.Today.AddDays(3))
                    this.Items[3].Add(item.Tracked.Description);
                else if (date == DateTime.Today.AddDays(4))
                    this.Items[4].Add(item.Tracked.Description);
                else if (date == DateTime.Today.AddDays(5))
                    this.Items[5].Add(item.Tracked.Description);
                else if (date == DateTime.Today.AddDays(6))
                    this.Items[6].Add(item.Tracked.Description);
            }
        }

        public List<List<string>> Items { get; set; }
    }
}
