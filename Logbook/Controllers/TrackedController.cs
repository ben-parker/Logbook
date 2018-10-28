using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logbook.Extensions;
using Logbook.Interfaces;
using Logbook.Models;
using Logbook.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Logbook.Controllers
{
    public class TrackedController : Controller
    {
        private ITrackedService _tracked;

        public TrackedController(ITrackedService tracked)
        {
            _tracked = tracked;
        }

        // GET: Tracked
        public ActionResult Index()
        {
            var items = _tracked.GetAll();
            List<TrackedIndexView> model = items.GroupBy(
                t => t.Category, 
                t => t, 
                (key, g) => new TrackedIndexView { Category = key.Description, Items = g.ToList() })
                .ToList();

            return View(model);
        }

        // GET: Tracked/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Tracked/Add
        public ActionResult Add()
        {
            AddTrackedView model = new AddTrackedView();
            model.Categories = _tracked.GetCategories().ToSelectList();
            model.RepeatOptions = new RepeatOptionSelectList().GetList();

            return View(model);
        }

        // POST: Tracked/Add
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(AddTrackedView model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                _tracked.Add(model);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {
                ModelState.AddModelError("Exception", e.Message);
                return View(model);
            }
        }

        // GET: Tracked/Edit/5
        public ActionResult Edit(int id)
        {
            var tracked = _tracked.Get(id);
            if (tracked is null)
            {
                return NotFound();
            }

            AddTrackedView model = _tracked.CreateView(tracked);

            return View(model);
        }

        // POST: Tracked/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AddTrackedView model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                _tracked.Update(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(model);
            }
        }

        // GET: Tracked/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Tracked/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}