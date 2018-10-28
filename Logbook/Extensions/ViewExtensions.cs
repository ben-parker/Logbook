using Logbook.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Logbook.Extensions
{
    public static class ViewExtensions
    {
        public static List<SelectListItem> ToSelectList(this IEnumerable<Category> categories)
        {
            return categories.Select(c => new SelectListItem
            {
                Text = c.Description,
                Value = c.CategoryId.ToString()
            })
            .ToList();
        }

        public static string GetEnumDescription(this Enum e)
        {
            FieldInfo fi = e.GetType().GetField(e.ToString());

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute),
                false);

            if (attributes.Length > 0)
            {
                return attributes[0].Description;
            }
            else
            {
                return e.ToString();
            }
        }

        public static string ToStringConditionalYear(this DateTime date)
        {
            if (DateTime.Now.Year == date.Year)
            {
                return date.ToString("MMM dd");
            }
            else
            {
                return date.ToString("MMM dd YYYY");
            }
        }

        public static string ToStringConditionalYear(this DateTime? nullableDate)
        {
            if (nullableDate is null) return String.Empty;

            DateTime date = nullableDate.Value;

            if (DateTime.Now.Year == date.Year)
            {
                return date.ToString("MMM dd");
            }
            else
            {
                return date.ToString("MMM dd YYYY");
            }
        }
    }
}
