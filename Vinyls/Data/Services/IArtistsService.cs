using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vinyls.Models;

namespace Vinyls.Data.Services
{
   public interface IArtistsService
    {
        Task<IEnumerable<Artist>> GetAll();
        Artist GetById(int id);
        void Add(Artist artist);
        Artist Update(int id, Artist newArtist);

        void Delete(int id);

    }
}
