using System;
using JobTrackingApp.Entities.Interfaces;

namespace JobTrackingApp.Entities.Concrete
{
    public class Job: IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Status { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}