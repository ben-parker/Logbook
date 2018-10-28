using Logbook.Interfaces;
using Logbook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logbook.Services
{
    public class InMemoryVehicleService : IVehicleService
    {
        private List<Car> _cars;
        private List<CarService> _services;

        public InMemoryVehicleService()
        {
            _cars = new List<Car>
            {
                new Car { Id = 1, Name = "Red Rocket", Year = 2008, Make = "Ford", Model = "Focus", Mileage = 102000 },
                new Car { Id = 2, Name = "Beanmachine", Year = 2010, Make = "Honda", Model = "Civic Si", Mileage = 98000 },
            };

            _services = new List<CarService>
            {
                new CarService { Id = 1, Car = _cars[1], Description = "Oil Change", Date = new DateTime(2018, 08, 04), Cost = 45, Mileage = 98003 },
                new CarService { Id = 2, Car = _cars[1], Description = "Tire Rotation", Date = new DateTime(2018, 03, 15), Cost = 99, Mileage = 96577 },
                new CarService { Id = 3, Car = _cars[1], Description = "Tune up", Date = new DateTime(2017, 10, 25), Cost = 124, Mileage = 94511 }
            };
        }

        public Car Get(int Id)
        {
            var car = _cars.Where(c => c.Id == Id).FirstOrDefault();
            car.Services = _services.Where(s => s.Car == car);

            return car;
        }

        public IEnumerable<Car> GetAll()
        {
            var cars = _cars.Select(c => {
                c.Services = _services.Where(s => s.Car.Equals(c));
                return c;
            });

            return cars;
        }
    }
}
