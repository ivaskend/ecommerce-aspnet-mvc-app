using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vinyls.Models
{
    public class ApplicationUser:IdentityUser
    {
        [Display(Name ="Име и презиме")]
        public string FullName { get; set; }
    }
}
