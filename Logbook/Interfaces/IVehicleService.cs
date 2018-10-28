using Logbook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logbook.Interfaces
{
    public interface IVehicleService
    {
        Car Get(int Id);

        IEnumerable<Car> GetAll();
    }
}
