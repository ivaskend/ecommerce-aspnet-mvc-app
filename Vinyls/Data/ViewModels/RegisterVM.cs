using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vinyls.Data.ViewModels
{
    public class RegisterVM
    {
        [Display(Name = "Име и презиме")]
        [Required(ErrorMessage = "Задолжително поле")]
        public string FullName { get; set; }

        [Display(Name ="Електронска пошта")]
        [Required(ErrorMessage ="Задолжително поле")]
        public string EmailAddress { get; set; }

        [Display(Name = "Лозинка")]
        [Required(ErrorMessage = "Задолжително поле")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Потврди лозинка")]
        [Required(ErrorMessage = "Задолжително поле")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Лозинките не се исти")]
        public string ConfirmPassword { get; set; }
    }
}
