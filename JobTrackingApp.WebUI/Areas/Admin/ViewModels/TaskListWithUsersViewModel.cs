using System.Collections.Generic;
using JobTrackingApp.Entities.Concrete;

namespace JobTrackingApp.WebUI.Areas.Admin.ViewModels
{
    public class TaskListWithUsersViewModel
    {
        public TaskListViewModel TaskListViewModel { get; set; }
        public List<AppUserListViewModel> Users { get; set; }

        public int activePage { get; set; }
        public int totalPageCount { get; set; }
        public string searchParam { get; set; }
    }
}