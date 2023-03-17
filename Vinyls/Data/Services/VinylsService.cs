using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vinyls.Data.Base;
using Vinyls.Models;

namespace Vinyls.Data.Services
{
    public class VinylsService:EntityBaseRepository<Vinyl>, IVinylsService
    {
        private readonly AppDbContext _context;
        public VinylsService(AppDbContext context):base(context)
        {
            _context = context;
        }

        public async Task<Vinyl> GetVinylByIdAsync(int id)
        {
            var vinylDetails = await _context.Vinyls
                .Include(ag => ag.AlbumGenre)
                .Include(rl => rl.RecordLabel)
                .Include(va => va.Artist_Vinyls).ThenInclude(a => a.Artist)
                .FirstOrDefaultAsync(n => n.Id == id);

            return  vinylDetails;
        }
    }
}
