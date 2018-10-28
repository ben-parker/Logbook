using Logbook.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Logbook.ViewModels
{
    public class AddTrackedView : Tracked
    {
        public List<SelectListItem> RepeatOptions { get; set; }
        public RepeatOption RepeatSelection { get; set; }

        [DataType(DataType.Currency)]
        public decimal? Cost { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; }
        public IEnumerable<Done> Occurrences { get; set; }
    }
}
