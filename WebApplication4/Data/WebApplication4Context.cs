using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication4.Models;
using Newtonsoft.Json;

namespace WebApplication4.Data
{
    public class WebApplication4Context : DbContext
    {
        public WebApplication4Context (DbContextOptions<WebApplication4Context> options)
            : base(options)
        {
        }



        public DbSet<WebApplication4.Models.NewCityWeather> NewCityWeather { get; set; }

        //public NewCityWeather AddDataToBase(string cityName)
        //{
        //    var newCityWeather = new NewCityWeather();
        //    newCityWeather.Name = cityName;
        //    newCityWeather = JsonConvert.DeserializeObject<NewCityWeather>(newCityWeather.GetWeather());
        //    return newCityWeather;
        //}

    }
}
