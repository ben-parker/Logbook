using Logbook.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Logbook.Models
{
    public class CarService
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; } 
        public int Mileage { get; set; }
        public bool Remind { get; set; } = false;
        public bool Repeat { get; set; } = false;
        public bool MarkDone { get; set; } = true;

        [DataType(DataType.Currency)]
        public Decimal Cost { get; set; }

        public Car Car { get; set; }
    }
}
