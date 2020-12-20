using System.Collections.Generic;
using JobTrackingApp.Entities.Concrete;

namespace JobTrackingApp.WebUI.Areas.Admin.ViewModels
{
    public class TaskListWithUsersViewModel
    {
        public TaskListViewModel TaskListViewModel { get; set; }
        public List<AppUserListViewModel> Users { get; set; }
    }
}