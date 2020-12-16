using System.Collections.Generic;
using JobTrackingApp.Entities.Interfaces;

namespace JobTrackingApp.Entities.Concrete
{
    public class Priority: IEntity
    {
        public int Id { get; set; }
        public string Level { get; set; }

        public virtual List<Task> Tasks { get; set; }
    }
}