using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Vinyls.Models
{
    public class AlbumGenre
    {
        [Key]
        public int Id { get; set; }
        [Display(Name="Име")]
        public string Name { get; set; }
        [Display(Name = "Опис")]

        public string Description { get; set; }

        //Relationships

        public List<Vinyl> Vinyls { get; set; }
    }
}
