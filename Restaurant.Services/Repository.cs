using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Restaurant.Entity;
using Restuarant.DTOModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Services
{
    public class Repository : IRepository
    {
        private readonly DbContext.DbContext context;
        private readonly IMapper _mapper;
        public Repository(DbContext.DbContext dbContext, IMapper mapper)
        {
            context = dbContext ??
                     throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ??
                   throw new ArgumentNullException(nameof(mapper));
        }

        //Add
        public Entity.Restaurant AddRestaurant(Entity.Restaurant restaurant)
        {
            context.Restaurants.Add(restaurant);
            Save();
            //foreach (RestaurantCuisine restaurantCuisine in restaurant.RestaurantCuisine.ToList())
            //   AddCuisineType(restaurant.Id ,restaurantCuisine.CuisineType);
            return restaurant;
        }
        public Ratings AddRating(int restaurantId, Ratings rating)
        {
            rating.RestaurantId = restaurantId;
            context.Ratings.Add(rating);
            Save();
            return rating;
        }
        public CuisineType AddCuisineType(int restaurantId, CuisineType cuisineType)
        {
            int cuisineId;
            var typeAvailablity = context.CuisineTypes
                        .FirstOrDefault(c=>c.Type.ToLower() == cuisineType.Type.ToLower());
            if (typeAvailablity == null)
            {
                context.CuisineTypes.Add(cuisineType);
                context.SaveChanges();
                cuisineId = cuisineType.Id;
            }
            else 
            {
                cuisineId = typeAvailablity.Id;
            }
            AddToRestaurantCuisineTable(cuisineId, restaurantId);
            return context.CuisineTypes.FirstOrDefault(c => c.Id == cuisineId);
        }
        private void AddToRestaurantCuisineTable(int cuisineId,int restaurantId)
        {
            if (context.RestaurantCuisines.FirstOrDefault(r => r.CuisineTypeId == cuisineId
                                                && r.RestaurantId == restaurantId) == null)
            {
                RestaurantCuisine restaurantCuisines = new RestaurantCuisine();
                restaurantCuisines.CuisineTypeId = cuisineId;
                restaurantCuisines.RestaurantId = restaurantId;
                context.RestaurantCuisines.Add(restaurantCuisines);
                context.SaveChanges();
            }
        }


        //GEtAll
        public async Task<IEnumerable<Entity.Restaurant>> GetRestaurants()
        {
            return await context.Restaurants.Include(r => r.Ratings)
                                       .Include(r => r.RestaurantCuisine)
                                        .ThenInclude(rc => rc.CuisineType).ToListAsync();
        }
        public async Task<IEnumerable<Entity.Restaurant>> GetRestaurants(string state, string searchQuery)
        {
            if (string.IsNullOrWhiteSpace(state) && string.IsNullOrWhiteSpace(searchQuery))
            {
                return await GetRestaurants();
            }
            var collection = context.Restaurants as IQueryable<Entity.Restaurant>;

            if (!string.IsNullOrWhiteSpace(state))
            {
                state = state.Trim();
                collection = collection.Where(r => r.State == state);
            }

            if (!string.IsNullOrWhiteSpace(searchQuery))
            {
                searchQuery = searchQuery.Trim();
                collection = collection.Where(r => r.Name.Contains(searchQuery)
                                               || r.City.Contains(searchQuery)
                                                || r.Street.Contains(searchQuery)
                                                 || r.Locality.Contains(searchQuery));
            }
            return await collection.ToListAsync();
        }
        public async Task<IEnumerable<CuisineType>> GetCuisineTypes(int restaurantId)
        {
            List<CuisineType> cuisineType = new List<CuisineType>();
            var RestaurantCuisinesList =await context.RestaurantCuisines.Where(rc => rc.RestaurantId == restaurantId)
                                    .Include(rc => rc.CuisineType)
                                        .ToListAsync();

            foreach (var restaurantCuisines in RestaurantCuisinesList)
                cuisineType.Add(restaurantCuisines.CuisineType);

            return cuisineType;
        }     
        public async Task<IEnumerable<Ratings>> GetRatings(int restaurantId)
        {
            return await context.Ratings.Where(r => r.RestaurantId == restaurantId).ToListAsync();
        }


        //GETOne
        public async Task<RestaurantCuisine> GetCuisineTypes(int restaurantId, int cuisineId)
        {
            return await context.RestaurantCuisines.Include(rc => rc.CuisineType)
                                             .FirstOrDefaultAsync(rc => rc.RestaurantId == restaurantId
                                                && rc.CuisineTypeId == cuisineId);

        }
        public async Task<Ratings> GetRatings(int restaurantId, int ratingId)
        {
            return await context.Ratings.FirstOrDefaultAsync(r => r.RestaurantId == restaurantId
                                           && r.Id == ratingId);
        }
        public async Task<Entity.Restaurant> GetRestaurants(int restaurantId)
        {
            Entity.Restaurant restaurant = await context.Restaurants.Where(r => r.Id == restaurantId)
                                                        .Include(r => r.Ratings)
                                                        .Include(r => r.RestaurantCuisine)
                                                        .ThenInclude(rc => rc.CuisineType)
                                                        .FirstOrDefaultAsync();
            return restaurant;
        }


        //UPDATE
        public async Task UpdateRestaurant(int restaurantId, RestaurantDtoForUpdate restaurant)
        {
            var restaurantFromRepo = await GetRestaurants(restaurantId);
            _mapper.Map(restaurant, restaurantFromRepo);
        }
        public async Task UpdateRatings(int restaurantId, int ratingId, RatingsDto ratings)
        {
            var ratingOfRestaurant = await GetRatings(restaurantId, ratingId);
            ratingOfRestaurant.Rating = ratings.Rating;
        }

        //Delete
        public async Task DeleteRating(int ratingId)
        {
            var ratings =await context.Ratings.FirstOrDefaultAsync(r => r.Id == ratingId);
            context.Ratings.Remove(ratings);
        }
        public async Task DeleteRestaurant(int restaurantId)
        {
            var restaurant = await GetRestaurants(restaurantId);
            context.Restaurants.Remove(restaurant);
        }
        public async Task DeleteCuisineType(int cuisineId)
        {
            var cuisine = await context.RestaurantCuisines.FirstOrDefaultAsync(rc => rc.CuisineTypeId == cuisineId);
            context.RestaurantCuisines.Remove(cuisine);
        }


        //extra
        public async Task<bool> RestaurantExists(int restaurantId)
        {
            if (await context.Restaurants.FirstOrDefaultAsync(r => r.Id == restaurantId) == null)
            {
                return false;
            }

            return true;
        }
        public void Save()
        {
            context.SaveChangesAsync();
        }
        ~Repository()
        {
            context.DisposeAsync();
        }
    }
}
