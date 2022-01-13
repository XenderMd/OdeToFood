using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
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

        public IEnumerable<Restaurant> GetAll()
        {
            return from r in restaurants orderby r.Name select r;
        }
    }
}
