using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
    }

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

        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            return from r in restaurants
            where string.IsNullOrEmpty(name)|| r.Name.StartsWith(name)
            orderby r.Name 
            select r;
        }
    }
}
