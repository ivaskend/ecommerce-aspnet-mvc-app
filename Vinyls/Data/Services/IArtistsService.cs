using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vinyls.Models;

namespace Vinyls.Data.Services
{
   public interface IArtistsService
    {
        Task<IEnumerable<Artist>> GetAllAsync();
        Task<Artist> GetByIdAsync(int id);
        Task AddAsync(Artist artist);
        Task<Artist> UpdateAsync(int id, Artist newArtist);

        Task  DeleteAsync(int id);

    }
}
