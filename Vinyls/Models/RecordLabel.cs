using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Vinyls.Data.Base;

namespace Vinyls.Models
{
    public class RecordLabel :IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display (Name ="Слика")]
        [Required(ErrorMessage ="Внесување на слика е задолжително")]
        public string ProfilePictureURL { get; set; }
        [Display(Name = " Целосно име")]
        [Required(ErrorMessage = "Внесување на име е задолжително")]
        public string FullName { get; set; }
        [Display(Name = "Биографија")]
        [Required(ErrorMessage = "Внесување на биографија е задолжително")]


        public string Bio { get; set; }

        //Relationships

        public List<Vinyl> Vinyls { get; set; }

    }
}
