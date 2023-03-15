using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vinyls.Models
{
    public class Artist
    {
        [Key]
        public int Id { get; set; }

        [Display(Name ="Слика")]
        //[Required]
        public string ProfilePictureURL { get; set; }

        [Display(Name = "Име")]

        //[Required]

        public string FullName { get; set; }
        [Display(Name = "Биографија")]

        //[Required]

        public string Bio { get; set; }

        //Relationships

        public  List<Artist_Vinyl> Artist_Vinyls{ get; set; } 
    }
}
