using Logbook.Models;
using Logbook.ViewModels;
using System;
using System.Collections.Generic;

namespace Logbook.Interfaces
{
    public interface ITrackedService
    {
        Tracked Get(int Id);
        IEnumerable<Tracked> GetAll();
        IEnumerable<Tracked> GetByCategory(Category category);
        void Add(AddTrackedView item);
        void Update(AddTrackedView item);
        IEnumerable<Category> GetCategories();
        AddTrackedView CreateView(Tracked tracked);
        IEnumerable<Done> GetOccurrences(Tracked tracked);
        IEnumerable<RepeatOptionSelectList> GetRepeatOptions();
    }
}
