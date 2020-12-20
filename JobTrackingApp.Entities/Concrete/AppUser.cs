using System.Collections.Generic;
using JobTrackingApp.Entities.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace JobTrackingApp.Entities.Concrete
{
    public class AppUser: IdentityUser<int>, IEntity
    {
        public string FirstName { get; set; }
        public string SurName { get; set; }
        public string Picture { get; set; }

        public virtual List<Task> Tasks { get; set; }
    }
}