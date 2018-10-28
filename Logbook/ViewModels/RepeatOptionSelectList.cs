using Logbook.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Logbook.ViewModels
{
    public class RepeatOptionSelectList
    {
        List<SelectListItem> _options;

        public RepeatOptionSelectList()
        {
            _options = new List<SelectListItem>
            {
                new SelectListItem { Text = "Never", Value = RepeatOption.Never.ToString() },
                new SelectListItem { Text = "Daily", Value = RepeatOption.Daily.ToString() },
                new SelectListItem { Text = "Weekly", Value = RepeatOption.Weekly.ToString() },
                new SelectListItem { Text = "Monthly", Value = RepeatOption.Monthly.ToString() },
                new SelectListItem { Text = "Yearly", Value = RepeatOption.Yearly.ToString() },
                new SelectListItem { Text = "Custom...", Value = RepeatOption.Custom.ToString() }
            };
        }

        public List<SelectListItem> GetList()
        {
            return _options;
        }
    }
}

