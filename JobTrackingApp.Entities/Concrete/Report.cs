using JobTrackingApp.Entities.Interfaces;

namespace JobTrackingApp.Entities.Concrete
{
    public class Report: IEntity
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Detail { get; set; }

        public int TaskId { get; set; }
        public virtual Task Task { get; set; }
    }
}