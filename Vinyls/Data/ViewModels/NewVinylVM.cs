using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Vinyls.Data;
using Vinyls.Data.Base;

namespace Vinyls.Models
{
    public class NewVinylVM 
      {
        public int Id { get; set; }
        [Display(Name ="Име на плоча")]
        [Required(ErrorMessage ="Името е задолжително")]
        public string Name { get; set; }

        [Display(Name = "Опис")]
        [Required(ErrorMessage = "Опис е задолжително")]
        public string Description { get; set; }

        [Display(Name = "Цена")]
        [Required(ErrorMessage = "Цената е задолжително")]
        public double Price { get; set; }

        [Display(Name = "Постер")]
        [Required(ErrorMessage = "постерот на плочата е задолжително")]
        public string ImageURL { get; set; }

        [Display(Name = "Детали")]
        [Required(ErrorMessage = "Детали е задолжително")]
        public string Details { get; set; }

        [Display(Name = "Формат")]
        [Required(ErrorMessage = "Форматот на плочата е задолжителен")]

        public AlbumFormat AlbumFormat { get; set; }

        [Display(Name = "Избери артист(и)")]
        [Required(ErrorMessage = "Артистот е задолжителен")]
        public List<int> ArtistIds { get; set; }

        [Display(Name = "Жанр")]
        [Required(ErrorMessage = "Жанрот е задолжителен")]
        public int AlbumGenreId { get; set; }
        [Display(Name = "Издавачка куќа")]
        [Required(ErrorMessage = "Издавачка кужа  е задолжително поле")]

        public int RecordLabelId { get; set; }

    }
}
