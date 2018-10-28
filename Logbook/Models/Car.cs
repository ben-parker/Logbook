using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Logbook.Models
{
    public class Car : IEquatable<Car>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Range(typeof(int), "0", "999999")]
        public int Mileage { get; set; }

        [Range(typeof(int), "1930", "2020")]
        public int Year { get; set; }

        public string Make { get; set; }
        public string Model { get; set; }

        public IEnumerable<CarService> Services { get; set; }

        public bool Equals(Car other)
        {
            if (other == null)
            {
                return false;
            }

            return other.Id == Id ? true : false;
        }
    }
}
