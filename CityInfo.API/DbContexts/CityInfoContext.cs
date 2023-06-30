using CityInfo.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace CityInfo.API.DbContexts
{
    public class CityInfoContext : DbContext
    {
        public DbSet<City> Cities { get; set; } = null!;
        public DbSet<PointOfInterest> PointOfInterests { get; set; } = null!;

        public CityInfoContext(DbContextOptions<CityInfoContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // add data
            modelBuilder.Entity<City>().HasData(
                new City("Ney York")
                {
                    Id = 1,
                    Description = "The one with that big park."
                },
                new City("Antwerp")
                {
                    Id = 2,
                    Description = "The one with the cathedral that ws never really finished."
                },
                new City("Paris")
                {
                    Id = 3,
                    Description = "The one with that big tower."
                });

            modelBuilder.Entity<PointOfInterest>().HasData(
                new PointOfInterest("Central Park")
                {
                    Id= 1,
                    CityId = 1,
                    Description = "The most vvisited urban park in the United States."
                },
                new PointOfInterest("Empire State Building")
                {
                    Id = 2,
                    CityId = 1,
                    Description = "A 102-story skyscraper locates in Midtown Manhattan."
                },
                new PointOfInterest("Cathedral")
                {
                    Id = 3,
                    CityId = 2,
                    Description = "desc."
                },
                new PointOfInterest("Eiffel Tower")
                {
                    Id = 5,
                    CityId = 3,
                    Description = "A wrought iron lattice tower on the Champ de Mars,..."
                },
                new PointOfInterest("The Louvre")
                {
                    Id = 6,
                    CityId = 3,
                    Description = "The world's largest museum."
                });
            base.OnModelCreating(modelBuilder);
        }

        // way #1 to configure our DbContext override OnConfiguring method,
        // another w,ays is on the constructor
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlite("connectionstring");
        //    base.OnConfiguring(optionsBuilder);
        //}

    }

}
