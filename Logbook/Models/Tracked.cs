using Logbook.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Logbook.Models
{
    public class Tracked
    {
        public int TrackedId { get; set; }
        public string Description { get; set; }
        public bool Remind { get; set; } = true;
        public bool IsRecurring { get; set; } = false;
        public bool Complete { get; set; } = false;

        [DataType(DataType.Date)]
        [Display(Name = "On")]
        public DateTime? DueDate { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Until")]
        public DateTime? EndDate { get; set; }

        public Recurrence Recurrence { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public IEnumerable<Done> Done { get; set; }
    }
}
