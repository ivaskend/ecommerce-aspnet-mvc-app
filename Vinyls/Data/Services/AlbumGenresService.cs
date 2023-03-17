using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vinyls.Data.Base;
using Vinyls.Models;

namespace Vinyls.Data.Services
{
    public class AlbumGenresService:EntityBaseRepository<AlbumGenre>, IAlbumGenresService
    {
        public AlbumGenresService(AppDbContext context): base(context)
        {
        }
    }
}
