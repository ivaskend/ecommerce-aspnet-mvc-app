using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vinyls.Data.ViewModels
{
    public class LoginVM
    {
        [Display(Name ="Електронска пошта")]
        [Required(ErrorMessage ="Задолжително поле")]
        public string EmailAddress { get; set; }

        [Display(Name = "Лозинка")]
        [Required(ErrorMessage = "Задолжително поле")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
