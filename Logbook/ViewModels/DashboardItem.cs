using Logbook.Models;
using System;

namespace Logbook.ViewModels
{
    public class DashboardItem
    {
        public int OccurrenceId { get; set; }
        public string Description { get; set; }
        public string DueDate { get; set; }
        public Done LastCompleted { get; set; }
        public string LastCompletedDate { get; set; }
        public string CompletedDate { get; set; }
    }
}