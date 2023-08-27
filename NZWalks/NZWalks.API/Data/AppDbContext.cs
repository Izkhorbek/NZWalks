using Microsoft.EntityFrameworkCore;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Data
{
    public class AppDbContext:DbContext
    {
     
        public AppDbContext(DbContextOptions<AppDbContext>  options):base(options)
        {
         
        }

        public DbSet<Walk> Walks { get; set; }
        public DbSet<Region> Regions { get; set; }  
        public DbSet<WalkDifficulty> WalkDifficulty { get; set; } 


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
