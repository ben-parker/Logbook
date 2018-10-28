using Logbook.Extensions;
using Logbook.Interfaces;
using Logbook.Models;
using Logbook.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Logbook.Services
{
    public class InMemoryTrackedService : ITrackedService
    {
        private List<Category> _categories;
        private List<Tracked> _items;
        private List<Done> _done;

        public InMemoryTrackedService()
        {
            _categories = new List<Category>
            {
                new Category { CategoryId = 1, Description = "Birthdays" },
                new Category { CategoryId = 2, Description = "824 Catalpa St" }
            };

            _items = new List<Tracked>
            {
                new Tracked {
                    TrackedId = 1,
                    Description = "Shawna's Birthday",
                    Category =  _categories[0],
                    Remind = true,
                },
                new Tracked
                {
                    TrackedId = 2,
                    Description = "Change furnace filter",
                    Category =  _categories[1],
                    Remind = true,
                }
            };

            _done = new List<Done>
            {
                new Done { DoneId = 1, TrackedId = 2, CompletedDate = DateTime.Today}
            };

        }

        public void Add(AddTrackedView item)
        {
            Tracked tracked = new Tracked
            {
                TrackedId = item.TrackedId,
                Description = item.Description,
                Remind = item.Remind,
                Category = item.Category,
            };

            tracked.TrackedId = _items.Max(i => i.TrackedId) + 1;

            _items.Add(tracked);
        }

        public void Update(AddTrackedView item)
        {
            var tracked = _items.Find(i => i.TrackedId == item.TrackedId);
            _items.Remove(tracked);

            Tracked add = new Tracked
            {
                TrackedId = item.TrackedId,
                Description = item.Description,
                Remind = item.Remind,
                Category = item.Category,
            };

            _items.Add(add);
        }

        public Tracked Get(int Id)
        {
            return _items.Where(i => i.TrackedId == Id).FirstOrDefault();
        }

        public IEnumerable<Tracked> GetAll()
        {
            return _items;
        }

        public IEnumerable<Tracked> GetByCategory(Category category)
        {
            return _items.Where(i => i.Category.Equals(category));
        }

        public IEnumerable<Category> GetCategories()
        {
            return _categories;
        }

        public IEnumerable<Done> GetOccurrences(Tracked tracked)
        {
            return _done.Where(d => d.TrackedId == tracked.TrackedId);
        }

        public AddTrackedView CreateView(Tracked tracked)
        {

            AddTrackedView view = new AddTrackedView
            {
                TrackedId = tracked.TrackedId,
                Description = tracked.Description,
                Remind = tracked.Remind,
                Category = tracked.Category,
                Categories = GetCategories().ToSelectList(),
                Occurrences = GetOccurrences(tracked)
            };

            return view;
        }

        public IEnumerable<RepeatOptionSelectList> GetRepeatOptions()
        {
            throw new NotImplementedException();
        }
    }
}
