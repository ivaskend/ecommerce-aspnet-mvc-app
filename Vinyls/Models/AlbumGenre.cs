using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Vinyls.Data.Base;

namespace Vinyls.Models
{
    public class AlbumGenre:IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Display(Name="Тип")]
        [Required(ErrorMessage ="Задолжително поплнете име")]
        public string Name { get; set; }
        [Display(Name = "Опис")]
        [Required(ErrorMessage = "Задолжително поплнете опис")]


        public string Description { get; set; }

        //Relationships

        public List<Vinyl> Vinyls { get; set; }
    }
}
