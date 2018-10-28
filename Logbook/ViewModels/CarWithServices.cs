using Logbook.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Logbook.ViewModels
{
    public class CarWithServices
    {
        public string Name { get; set; }

        [Range(typeof(int), "0", "999999")]
        public int Mileage { get; set; }

        [Range(typeof(int), "1930", "2020")]
        public int Year { get; set; }

        public string Make { get; set; }
        public string Model { get; set; }

        public IEnumerable<CarService> Services { get; set; }
    }
}
