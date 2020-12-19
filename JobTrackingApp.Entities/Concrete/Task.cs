using System;
using System.Collections.Generic;
using JobTrackingApp.Entities.Interfaces;

namespace JobTrackingApp.Entities.Concrete
{
    public class Task: IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public bool Status { get; set; }
        
        public int? AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public int PriorityId { get; set; }
        public virtual Priority Priority { get; set; }

        public virtual List<Report> Reports { get; set; }
    }
}