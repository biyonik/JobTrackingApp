using System.ComponentModel.DataAnnotations;

namespace JobTrackingApp.WebUI.Areas.Admin.ViewModels
{
    public class PriorityAddViewModel
    {
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz")]
        [Display(Name = "Tanım")]
        public string Level { get; set; }
    }
}