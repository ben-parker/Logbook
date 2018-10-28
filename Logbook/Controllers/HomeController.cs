using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Logbook.Models;
using Logbook.Interfaces;
using Logbook.ViewModels;
using Logbook.Extensions;

namespace Logbook.Controllers
{
    public class HomeController : Controller
    {
        private IDoneService _done;

        public HomeController(IDoneService done)
        {
            _done = done;
        }

        public IActionResult Index()
        {
            DateTime untilDate = DateTime.Today.AddDays(30);
            DateTime sinceDate = DateTime.Today.AddDays(-30);
            DashboardView model = new DashboardView
            {
                Calendar = new DashboardCalendarView(_done.GetWeek()),

                Upcoming = _done.GetUpcoming(untilDate)
                .Select(i => new DashboardItem
                {
                    Description = i.Tracked.Description,
                    DueDate = i.DueDate.ToStringConditionalYear(),
                    LastCompleted = _done.GetMostRecentlyCompleted(i.TrackedId),
                    CompletedDate = i.CompletedDate.ToStringConditionalYear(),
                    OccurrenceId = i.DoneId
                })
                .AsEnumerable(),

                Recent = _done.GetRecentlyCompleted(sinceDate).Select(i => new DashboardItem
                {
                    Description = i.Tracked.Description,
                    DueDate = i.DueDate.ToStringConditionalYear(),
                    LastCompleted = _done.GetMostRecentlyCompleted(i.TrackedId),
                    CompletedDate = i.CompletedDate.ToStringConditionalYear(),
                    OccurrenceId = i.DoneId
                })
                .AsEnumerable()
            };

            return View(model);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
