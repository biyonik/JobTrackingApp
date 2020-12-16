using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace JobTrackingApp.Entities.Concrete
{
    public class AppUser: IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string SurName { get; set; }

        public virtual List<Task> Tasks { get; set; }
    }
}