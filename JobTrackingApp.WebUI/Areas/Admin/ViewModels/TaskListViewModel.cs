using System;
using JobTrackingApp.Entities.Concrete;

namespace JobTrackingApp.WebUI.Areas.Admin.ViewModels
{
    public class TaskListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Status { get; set; }
        public int PriorityId { get; set; }
        public Priority Priority { get; set; }
        
    }
}