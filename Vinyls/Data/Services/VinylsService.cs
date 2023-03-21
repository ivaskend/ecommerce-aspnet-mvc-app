using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vinyls.Data.Base;
using Vinyls.Data.ViewModels;
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

        public async Task AddNewVinylAsync(NewVinylVM data)
        {
            var newVinyl = new Vinyl()
            {
                Name = data.Name,
                Description = data.Description,
                Price = data.Price,
                ImageURL = data.ImageURL,
                AlbumGenreId = data.AlbumGenreId,
                Details = data.Details,
                AlbumFormat = data.AlbumFormat,
                RecordLabelId = data.RecordLabelId
            };
            await _context.Vinyls.AddAsync(newVinyl);
            await _context.SaveChangesAsync();

            //Add Vinyl Artists

            foreach (var artistId in data.ArtistIds)
            {
                var newArtistVinyl = new Artist_Vinyl()
                {
                    VinylId = newVinyl.Id,
                    ArtistId = artistId
                };
                await _context.Artists_Vinyls.AddAsync(newArtistVinyl);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<NewVinylDropdownVM> GetNewVinylDropdownsValues()
        {
            var response = new NewVinylDropdownVM()
            {
                Artists = await _context.Artists.OrderBy(n => n.FullName).ToListAsync(),
                AlbumGenres = await _context.AlbumGenres.OrderBy(n => n.Name).ToListAsync(),
                RecordLabels = await _context.RecordLabels.OrderBy(n => n.FullName).ToListAsync()
            };

            return response;
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

        public async Task UpdateVinylAsync(NewVinylVM data)
        {
            var dbVinyl = await _context.Vinyls.FirstOrDefaultAsync(n => n.Id == data.Id);
            if (dbVinyl != null)
            {

                dbVinyl.Name = data.Name;
                dbVinyl.Description = data.Description;
                dbVinyl.Price = data.Price;
                dbVinyl.ImageURL = data.ImageURL;
                dbVinyl.AlbumGenreId = data.AlbumGenreId;
                dbVinyl.Details = data.Details;
                dbVinyl.AlbumFormat = data.AlbumFormat;
                dbVinyl.RecordLabelId = data.RecordLabelId;
                await _context.SaveChangesAsync();

            }
            //Remove existing artists

            var existingArtistDb = _context.Artists_Vinyls.Where(n => n.VinylId == data.Id).ToList();
             _context.Artists_Vinyls.RemoveRange(existingArtistDb);
            await _context.SaveChangesAsync();


            //Add Vinyl Artists
            foreach (var artistId in data.ArtistIds)
            {
                var newArtistVinyl = new Artist_Vinyl()
                {
                    VinylId = data.Id,
                    ArtistId = artistId
                };
                await _context.Artists_Vinyls.AddAsync(newArtistVinyl);
            }
            await _context.SaveChangesAsync();

        }
    }
}
