using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data
{
    public class InmMemoryRestaurantData : IRestaurantData
    {
        readonly List<Restaurant> restaurants;

        public InmMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant {ID = 1, Name="Scott's Pizza", Location="Maryland", Cuisine=CuisineType.Italian },
                new Restaurant {ID = 2, Name="Denis's Burrito", Location="Orhei", Cuisine=CuisineType.Mexican },
                new Restaurant {ID = 3, Name="Dan's Nacho", Location="Orhei", Cuisine=CuisineType.Mexican },
                new Restaurant {ID = 4, Name="The SpicyLand", Location="Cluj", Cuisine=CuisineType.Indian },
            };
        }

        public int Commit(){return 0;}

        public Restaurant GetByID(int id){
            return restaurants.SingleOrDefault(r=>r.ID==id);
        }
        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            return from r in restaurants
            where string.IsNullOrEmpty(name)|| r.Name.StartsWith(name)
            orderby r.Name 
            select r;
        }
        public Restaurant Add(Restaurant newRestaurant){
            newRestaurant.ID=restaurants.Max(restaurant=>restaurant.ID)+1;
            restaurants.Add(newRestaurant);
            return newRestaurant;
        }
        public Restaurant Update(Restaurant updatedRestaurant){
            var restaurant = restaurants.SingleOrDefault(restaurant=>restaurant.ID==updatedRestaurant.ID);
            if(restaurant!=null){
                restaurant.Name=updatedRestaurant.Name;
                restaurant.Location=updatedRestaurant.Location;
                restaurant.Cuisine=updatedRestaurant.Cuisine;
            };
            return restaurant;
        }

        public Restaurant Delete(int id)
        {
            var restaurant = restaurants.FirstOrDefault(restaurant=>restaurant.ID==id);
            if(restaurant!=null){
                restaurants.Remove(restaurant);
            };
            return restaurant;
        }

        public int GetCountOfRestaurants()
        {
            return restaurants.Count();
        }
    }
}
