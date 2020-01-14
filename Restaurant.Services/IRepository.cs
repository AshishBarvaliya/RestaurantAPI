using System.Collections.Generic;
using System.Threading.Tasks;
using Restaurant.Entity;
using Restuarant.DTOModels;

namespace Restaurant.Services
{
    public interface IRepository
    {
        //Add
        public Entity.Restaurant AddRestaurant(Entity.Restaurant restaurant);
        public Ratings AddRating(int restaurantId, Ratings rating);
        public CuisineType AddCuisineType(int restaurantId, CuisineType cuisineType);
        
        //GetSingle
        public Task<Entity.Restaurant> GetRestaurants(int restaurantId);
        public Task<Ratings> GetRatings(int restaurantId,int ratingId);
        public Task<RestaurantCuisine> GetCuisineTypes(int cuisineTypeId, int cuisineId);

        //GetAll
        public Task<IEnumerable<Entity.Restaurant>> GetRestaurants();
        public Task<IEnumerable<Entity.Restaurant>> GetRestaurants(string state, string searchQuery);
        public Task<IEnumerable<Ratings>> GetRatings(int restaurantId);
        public Task<IEnumerable<CuisineType>> GetCuisineTypes(int restaurantId);

        //Delete
        public Task DeleteRating(int ratingId);
        public Task DeleteRestaurant(int restaurantId);
        public Task DeleteCuisineType(int cuisineId);

        //Update
        public Task UpdateRestaurant(int RestaurantId, RestaurantDtoForUpdate restaurant);
        public Task UpdateRatings(int restaurantId, int ratingId, RatingsDto ratings);

        //Extra
        public void Save();
        public Task<bool> RestaurantExists(int restaurantId);
    }
}