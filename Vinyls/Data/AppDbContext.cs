using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vinyls.Models;

namespace Vinyls.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artist_Vinyl>().HasKey(av => new
            {
                av.ArtistId,
                av.VinylId
            });

            modelBuilder.Entity<Artist_Vinyl>().HasOne(v => v.Vinyl).WithMany(av => av.Artist_Vinyls).HasForeignKey(v => v.VinylId);

            modelBuilder.Entity<Artist_Vinyl>().HasOne(v => v.Artist).WithMany(av => av.Artist_Vinyls).HasForeignKey(v => v.ArtistId);


            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Vinyl> Vinyls { get; set; }
        public DbSet<Artist_Vinyl> Artists_Vinyls { get; set; }
        public DbSet<AlbumGenre> AlbumGenres { get; set; }
        public DbSet<RecordLabel> RecordLabels { get; set; }


    }
}
