using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vinyls.Data.Base;
using Vinyls.Models;

namespace Vinyls.Data.Services
{
    public class ArtistsService : EntityBaseRepository<Artist>, IArtistsService
    {
        private readonly AppDbContext _context;

        public ArtistsService(AppDbContext context) :base(context) { }

    }
}
