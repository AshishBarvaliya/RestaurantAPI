using Microsoft.EntityFrameworkCore;
using Restaurant.Entity;

namespace Restaurant.DbContext
{
    public class DbContext: Microsoft.EntityFrameworkCore.DbContext
    {
        public DbContext(DbContextOptions<DbContext> options) : base(options) {    }

        public DbContext() { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Entity.Restaurant>().HasData(
               new Entity.Restaurant()
               {
                   Id = 1,
                   Name = "Tawa Ghar",
                   Street = "1st",
                   Locality = "HSR",
                   City = "Bangaluru",
                   State = "Karnataka",
                   Postcode = "2020",
                   Lat = 20.1020,
                   Lng = 20.1020
               },
               new Entity.Restaurant()
               {
                   Id = 2,
                   Name = "Menal Hotel",
                   Street = "Talwandi",
                   Locality = "Ganeshnagar",
                   City = "Kota",
                   State = "Rajasthan",
                   Postcode = "2121",
                   Lat = 21.1020,
                   Lng = 21.1020
               },
               new Entity.Restaurant()
               {
                   Id = 3,
                   Name = "Laxmi Hotel",
                   Street = "Varachha",
                   Locality = "Kapodra",
                   City = "Surat",
                   State = "Gujarat",
                   Postcode = "2222",
                   Lat = 22.1020,
                   Lng = 22.1020
               },
               new Entity.Restaurant()
               {
                   Id = 4,
                   Name = "Red Chilli Hotel",
                   Street = "Varachha",
                   Locality = "Simada",
                   City = "Surat",
                   State = "Gujarat",
                   Postcode = "2323",
                   Lat = 23.1020,
                   Lng = 23.1020
               }
               );
            modelBuilder.Entity<Ratings>().HasData(
                    new Ratings() { Id = 1, RestaurantId = 1, Rating = 5 },
                    new Ratings() { Id = 2, RestaurantId = 1, Rating = 9 },
                    new Ratings() { Id = 3, RestaurantId = 1, Rating = 7 },
                    new Ratings() { Id = 4, RestaurantId = 2, Rating = 2 },
                    new Ratings() { Id = 5, RestaurantId = 2, Rating = 3 },
                    new Ratings() { Id = 6, RestaurantId = 3, Rating = 8 },
                    new Ratings() { Id = 7, RestaurantId = 4, Rating = 5 }
                   );
            modelBuilder.Entity<CuisineType>().HasData(
                    new CuisineType() { Id = 1, Type = "Rajastani" },
                    new CuisineType() { Id = 2, Type = "Indian" },
                    new CuisineType() { Id = 3, Type = "Italian" },
                    new CuisineType() { Id = 4, Type = "Chinese" },
                    new CuisineType() { Id = 5, Type = "Gujarati" }
                );
            modelBuilder.Entity<RestaurantCuisine>().HasData(
                   new RestaurantCuisine() { Id = 1, RestaurantId = 1, CuisineTypeId = 2 },
                   new RestaurantCuisine() { Id = 2, RestaurantId = 1, CuisineTypeId = 3 },
                   new RestaurantCuisine() { Id = 3, RestaurantId = 1, CuisineTypeId = 4 },
                   new RestaurantCuisine() { Id = 4, RestaurantId = 2, CuisineTypeId = 3 },
                   new RestaurantCuisine() { Id = 5, RestaurantId = 2, CuisineTypeId = 1 },
                   new RestaurantCuisine() { Id = 6, RestaurantId = 3, CuisineTypeId = 5 },
                   new RestaurantCuisine() { Id = 7, RestaurantId = 4, CuisineTypeId = 1 }
                ) ;


            //   modelBuilder.Entity<RestaurantCuisine>()
            //      .HasKey(sc => new { sc.RestaurantId, sc.CuisineTypeId });
        }

        //entities
        public DbSet<Entity.Restaurant> Restaurants { get; set; }
        public DbSet<Ratings> Ratings { get; set; }
        public DbSet<CuisineType> CuisineTypes { get; set; }
        public DbSet<RestaurantCuisine> RestaurantCuisines { get; set; }
    }
}
