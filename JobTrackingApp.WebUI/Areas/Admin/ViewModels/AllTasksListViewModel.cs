using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using JobTrackingApp.Entities.Concrete;

namespace JobTrackingApp.WebUI.Areas.Admin.ViewModels
{
    public class AllTasksListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public AppUser AppUser { get; set; }
        
        public virtual Priority Priority { get; set; }

        public virtual List<Report> Reports { get; set; }
    }
}