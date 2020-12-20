using System.Collections.Generic;
using JobTrackingApp.BusinessLogic.Interfaces;
using JobTrackingApp.Entities.Concrete;
using JobTrackingApp.WebUI.Areas.Admin.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace JobTrackingApp.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class TaskController : Controller
    {
        private readonly ITaskService _taskService;
        private readonly IPriorityService _priorityService;

        public TaskController(ITaskService taskService, IPriorityService priorityService)
        {
            _taskService = taskService;
            _priorityService = priorityService;
        }
        // GET
        public IActionResult Index()
        {
            TempData["Active"] = "Task";
            List<Task> tasks = _taskService.GetAllIncompleteTasksWithPriority();
            List<TaskListViewModel> taskListViewModel = new List<TaskListViewModel>();
            tasks.ForEach(task =>
            {
                taskListViewModel.Add(new TaskListViewModel()
                {
                    Id = task.Id,
                    Description = task.Description,
                    Name = task.Name,
                    Status = task.Status,
                    CreatedDate = task.CreatedDate,
                    PriorityId = task.Priority.Id,
                    Priority = task.Priority
                });
            });
            return View(taskListViewModel);
        }

        public IActionResult Add()
        {
            TempData["Active"] = "Task";
            var priorityList = new SelectList(_priorityService.GetAll(), "Id", "Level");
            return View(new TaskAddViewModel()
            {
                PriorityList = priorityList
            });
        }

        [HttpPost]
        public IActionResult Add(TaskAddViewModel entity)
        {
            if (ModelState.IsValid)
            {
                _taskService.Add(new Task()
                {
                    Name = entity.Name,
                    Description = entity.Description,
                    PriorityId = entity.PriorityId
                });
                return RedirectToAction("Index", "Task");
            }
            return View(entity);
        }

        public IActionResult Edit(int id)
        {
            TempData["Active"] = "Task";
            Task task = _taskService.Get(id);
            List<StatusListViewModel> statusListViewModels = new List<StatusListViewModel>()
            {
                new StatusListViewModel() {Name = "Aktif", Value = true},
                new StatusListViewModel() {Name = "Pasif", Value = false}
            };
            TaskEditViewModel taskEditViewModel = new TaskEditViewModel()
            {
                Id = task.Id,
                Name = task.Name,
                Description = task.Description,
                PriorityId = task.PriorityId,
                PriorityList = new SelectList(_priorityService.GetAll(), "Id", "Level", task.PriorityId),
                Status = task.Status,
                StatusList = new SelectList(statusListViewModels, "Value", "Name", task.Status)
            };
            return View(taskEditViewModel);
        }

        [HttpPost]
        public IActionResult Edit(TaskEditViewModel entity)
        {
            if (ModelState.IsValid)
            {
                _taskService.Update(new Task()
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Description = entity.Description,
                    Status = entity.Status,
                    PriorityId = entity.PriorityId
                });
                return RedirectToAction("Index", "Task");
            }
            return View(entity);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Task task = new Task()
            {
                Id = id
            };
            _taskService.Delete(task);
            return Json(null);
        }
    }
}