using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace JobTrackingApp.WebUI.Areas.Admin.ViewModels
{
    public class TaskEditViewModel
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz!")]
        [Display(Name = "Adı")]
        public string Name { get; set; }
        
        [Display(Name = "Açıklama")]
        public string Description { get; set; }

        [Display(Name = "Durum")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz!")]
        public bool Status { get; set; }
        
        [Range(0, int.MaxValue, ErrorMessage = "Lütfen bir aciliyet durumu seçiniz!")]
        [Display(Name = "Aciliyet Durumu")]
        public int PriorityId { get; set; }
        
        public SelectList PriorityList { get; set; }
        public SelectList StatusList { get; set; }
    }
}