using System.Collections.Generic;
using JobTrackingApp.BusinessLogic.Interfaces;
using JobTrackingApp.Entities.Concrete;
using JobTrackingApp.WebUI.Areas.Admin.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace JobTrackingApp.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PriorityController : Controller
    {
        private readonly IPriorityService _priorityService;

        public PriorityController(IPriorityService priorityService)
        {
            _priorityService = priorityService;
        }
        
        public IActionResult Index()
        {
            TempData["Active"] = "Priority";
            List<Priority> priorities = _priorityService.GetAll();
            List<PriorityListViewModel> priorityListViewModels = new List<PriorityListViewModel>();
            priorities.ForEach(priority =>
            {
                priorityListViewModels.Add(new PriorityListViewModel()
                {
                    Id = priority.Id,
                    Level =  priority.Level
                });
            });
            return View(priorityListViewModels);
        }

        public IActionResult Add()
        {
            TempData["Active"] = "Priority";
            return View(new PriorityAddViewModel());
        }
        
        [HttpPost]
        public IActionResult Add(PriorityAddViewModel entity)
        {
            if (ModelState.IsValid)
            {
                _priorityService.Add(new Priority()
                {
                    Level = entity.Level
                });
                return RedirectToAction("Index", "Priority");
            }
            return View(entity);
        }
        
        public IActionResult Edit(int id)
        {
            TempData["Active"] = "Priority";
            Priority priority =  _priorityService.Get(id);
            PriorityEditViewModel priorityEditViewModel = new PriorityEditViewModel()
            {
                Id = priority.Id,
                Level = priority.Level
            };
            return View(priorityEditViewModel);
        }
        
        [HttpPost]
        public IActionResult Edit(PriorityEditViewModel entity)
        {
            if (ModelState.IsValid)
            {
                Priority newPriority = new Priority()
                {
                    Id = entity.Id,
                    Level = entity.Level
                };
                _priorityService.Update(newPriority);
                return RedirectToAction("Index", "Priority");
            }
            return View(entity);
        }
    }
}