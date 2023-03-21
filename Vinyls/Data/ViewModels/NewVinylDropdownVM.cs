using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vinyls.Models;

namespace Vinyls.Data.ViewModels
{
    public class NewVinylDropdownVM
    {
        public NewVinylDropdownVM()
        {
            RecordLabels = new List<RecordLabel>();
            AlbumGenres = new List<AlbumGenre>();
            Artists = new List<Artist>();

        }
        public List<RecordLabel> RecordLabels { get; set; }
        public List<AlbumGenre> AlbumGenres { get; set; }
        public List<Artist> Artists { get; set; }



    }
}
