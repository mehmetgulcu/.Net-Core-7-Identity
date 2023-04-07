using System.ComponentModel.DataAnnotations;

namespace NetCoreIdentity.Models
{
    public class UserCreateModel
    {
        [Required(ErrorMessage = "Kullanıcı adı gereklidir")]
        public string Username { get; set; }

        [EmailAddress(ErrorMessage = "Email formatı giriniz")]
        [Required(ErrorMessage = "Email adresi gereklidir")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Parola gereklidir")]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Parolalar eşleşmiyor")]
        public string ComfirmPassword { get; set; }
        [Required(ErrorMessage = "Cinsiyet alanı gereklidir")]
        public string Gender { get; set; }

    }
}
