using System.ComponentModel.DataAnnotations;

namespace JobTrackingApp.WebUI.Areas.Admin.ViewModels
{
    public class PriorityEditViewModel
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz")]
        [Display(Name = "Tanım")]
        public string Level { get; set; }
    }
}