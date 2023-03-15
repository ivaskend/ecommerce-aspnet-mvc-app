using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vinyls.Models
{
    public class RecordLabel
    {
        [Key]
        public int Id { get; set; }

        [Display (Name ="Слика")]
        public string ProfilePictureURL { get; set; }
        [Display(Name = "Име")]

        public string FullName { get; set; }
        [Display(Name = "Биографија")]

        public string Bio { get; set; }

        //Relationships

        public List<Vinyl> Vinyls { get; set; }

    }
}
