using System.Collections.Generic;
using JobTrackingApp.Entities.Interfaces;

namespace JobTrackingApp.Entities.Concrete
{
    public class User: IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public List<Job> Jobs { get; set; }
    }
}