using System.ComponentModel.DataAnnotations;

namespace JobTrackingApp.WebUI.ViewModels
{
    public class UserRegisterViewModel
    {
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz")]
        [Display(Name = "Kullanıcı Adı")]
        public string UserName { get; set; }
        
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz")]
        [DataType(DataType.Password)]
        [Display(Name = "Parola")]
        public string Password { get; set; }
        
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage = "Parolalar birbiriyle eşleşmiyor!")]
        [Display(Name = "Parola Tekrar")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "{0} alanı boş bırakılamaz")]
        [EmailAddress(ErrorMessage = "{0} alanı geçerli bir e-posta formatında olmalıdır")]
        [Display(Name = "E-Posta Adresi")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz")]
        [Display(Name = "İsim")]
        public string FirstName { get; set; }
        
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz")]
        [Display(Name = "Soyisim")]
        public string LastName { get; set; }
    }
}