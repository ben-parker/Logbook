using Logbook.Interfaces;
using Logbook.Models;
using Logbook.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Logbook.Services
{
    public class SQLTrackedService : ITrackedService
    {
        private LogbookDBContext _db;

        public SQLTrackedService(LogbookDBContext db)
        {
            _db = db;
        }

        public void Add(AddTrackedView item)
        {
            Tracked tracked = new Tracked
            {
                Description = item.Description,
                CategoryId = item.CategoryId,
                Remind = item.Remind,
                EndDate = item.EndDate
            };

            if (item.RepeatSelection > RepeatOption.Never)
            {
                tracked.IsRecurring = true;
                tracked.Recurrence = new Recurrence
                {
                    Interval = 1,
                    Frequency = ParseFrequencySelection(item.RepeatSelection)
                };
            }

            _db.Tracked.Add(tracked);

            //if (item.Repeat || item.DueDate != null || item.CompletedDate != null)
            //{
            //    Done occur = new Done
            //    {
            //        Tracked = tracked,
            //        DueDate = item.DueDate,
            //        CompletedDate = item.CompletedDate,
            //        Cost = item.Cost,
            //        Repeat = item.Repeat
            //    };

            //    _db.Done.Add(occur);
            //}

            _db.SaveChanges();

            ICalFrequency ParseFrequencySelection(RepeatOption repeat)
            {
                ICalFrequency frequency;

                if (repeat == RepeatOption.Daily) frequency = ICalFrequency.Daily;
                else if (repeat == RepeatOption.Weekly) frequency = ICalFrequency.Weekly;
                else if (repeat == RepeatOption.Monthly) frequency = ICalFrequency.Monthly;
                else if (repeat == RepeatOption.Yearly) frequency = ICalFrequency.Yearly;
                else frequency = null;

                return frequency;
            }
        }

        public AddTrackedView CreateView(Tracked tracked)
        {
            throw new NotImplementedException();
        }

        public Tracked Get(int Id)
        {
            return _db.Tracked.Find(Id);
        }

        public IEnumerable<Tracked> GetAll()
        {
            var results = _db.Tracked
                .Include("Category")
                .Include("Done")
                .AsEnumerable();

            return results;
        }

        public IEnumerable<Tracked> GetByCategory(Category category)
        {
            return _db.Tracked.Where(i => i.Category.Equals(category)).AsEnumerable();
        }

        public IEnumerable<Category> GetCategories()
        {
            return _db.Categories.AsEnumerable();
        }

        public IEnumerable<Done> GetOccurrences(Tracked tracked)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RepeatOptionSelectList> GetRepeatOptions()
        {
            throw new NotImplementedException();
        }

        public void Update(AddTrackedView item)
        {
            throw new NotImplementedException();
        }
    }
}
