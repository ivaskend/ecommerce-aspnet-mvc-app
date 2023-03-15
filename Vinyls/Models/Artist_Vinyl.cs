using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vinyls.Models
{
    public class Artist_Vinyl
    {
        public int VinylId { get; set; }
        public Vinyl Vinyl { get; set; }
        public int ArtistId { get; set; }
        public Artist Artist { get; set; }
    }
}
