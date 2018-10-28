using Logbook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logbook.ViewModels
{
    public class TrackedIndexView
    {
        public string Category { get; set; }
        public List<Tracked> Items { get; set; }
    }
}
