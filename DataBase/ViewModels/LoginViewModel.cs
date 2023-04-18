using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace DataBase
{
    public class LoginViewModel
    {
        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "لطفا{0}را وارد  کنید")]
        [MaxLength(200)]
        public string UserName { get; set; }

        [Display(Name = "کلمه ورود")]
        [Required(ErrorMessage = "لطفا{0}را وارد  کنید")]
        [MaxLength(200)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "مرا به  خاطر بسپار")]
        public bool RememberMe  { get; set; }
    }
}