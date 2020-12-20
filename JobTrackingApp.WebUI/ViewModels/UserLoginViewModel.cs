using System.ComponentModel.DataAnnotations;

namespace JobTrackingApp.WebUI.ViewModels
{
    public class UserLoginViewModel
    {
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz")]
        [Display(Name = "Kullanıcı Adı")]
        public string UserName { get; set; }
        
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz")]
        [DataType(DataType.Password)]
        [Display(Name = "Parola")]
        public string Password { get; set; }
        
        [Display(Name = "Beni Hatırla")]
        public bool RememberMe { get; set; }
    }
}