using System.Collections.Generic;
using JobTrackingApp.BusinessLogic.Interfaces;
using JobTrackingApp.Entities.Concrete;
using JobTrackingApp.WebUI.Areas.Admin.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JobTrackingApp.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class TaskOrderController : Controller
    {
        private readonly IAppUserService _appUserService;
        private readonly ITaskService _taskService;
        public TaskOrderController(IAppUserService appUserService, ITaskService taskService)
        {
            _appUserService = appUserService;
            _taskService = taskService;
        }
        public IActionResult Index()
        {
            TempData["Active"] = "TaskOrder";
            // var model = _appUserService.GetNonAdminUsers();
            List<Task> allTasks = _taskService.GetAllTasksWithRelatedEntities();
            List<AllTasksListViewModel> allTasksListViewModels = new List<AllTasksListViewModel>();
            allTasks.ForEach(allTask =>
            {
                allTasksListViewModels.Add(new AllTasksListViewModel()
                {
                    Id = allTask.Id,
                    Name = allTask.Name,
                    Description = allTask.Description,
                    CreatedDate = allTask.CreatedDate,
                    Priority = allTask.Priority,
                    Reports = allTask.Reports,
                    AppUser = allTask.AppUser
                });
            });
            return View(allTasksListViewModels);
        }

        public void Detail()
        {
            
        }

        public IActionResult AssignPersonel(int id, string searchParam, int activePage = 1)
        {
            TempData["Active"] = "TaskOrder";
            var task = _taskService.GetByPriority(id);
            var users = _appUserService.GetNonAdminUsers(searchParam, activePage);
            TaskListViewModel taskListViewModel = new TaskListViewModel()
            {
                Id = task.Id,
                Name = task.Name,
                Description = task.Description,
                Status = task.Status,
                CreatedDate = task.CreatedDate,
                Priority = task.Priority
            };
            
            List<AppUserListViewModel> appUserListViewModels = new List<AppUserListViewModel>();
            users.ForEach(user =>
            {
                appUserListViewModels.Add(new AppUserListViewModel()
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    SurName = user.SurName,
                    Email = user.Email,
                    Picture = user.Picture
                });
            });
            
            TaskListWithUsersViewModel taskListWithUsersViewModel = new TaskListWithUsersViewModel()
            {
                TaskListViewModel = taskListViewModel,
                Users = appUserListViewModels
            };
            
            return View(taskListWithUsersViewModel);
        }
    }
}