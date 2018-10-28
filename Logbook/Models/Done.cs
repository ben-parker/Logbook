using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Logbook.Models
{
    [Table("Done")]
    public class Done
    {
        [Required]
        public int DoneId { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Due on")]
        public DateTime? DueDate { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Completed on")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime CompletedDate { get; set; }

        [DataType(DataType.Currency)]
        public decimal? Cost { get; set; }

        [Required]
        public int TrackedId { get; set; }
        public Tracked Tracked { get; set; }
    }
}
