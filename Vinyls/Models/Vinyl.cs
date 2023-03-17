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
    public class Vinyl : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImageURL { get; set; }

        public string Details { get; set; }

        public AlbumFormat AlbumFormat { get; set; }


        //relationships

        public List<Artist_Vinyl> Artist_Vinyls { get; set; }

        //AlbumGenre

        public int AlbumGenreId { get; set; }
        [ForeignKey("AlbumGenreId")]
        public AlbumGenre AlbumGenre { get; set; }

        //RecordLabel

        public int RecordLabelId { get; set; }
        [ForeignKey("RecordLabelId")]
        public RecordLabel RecordLabel { get; set; }

    }
}
