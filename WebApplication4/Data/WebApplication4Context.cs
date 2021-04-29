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

        public DbSet<WebApplication4.Models.CityWeather> CityWeather { get; set; }

        public CityWeather AddDataToBase(string cityName)
        {
            var cityWeather = new CityWeather();
            cityWeather.Name = cityName;
            cityWeather = JsonConvert.DeserializeObject<CityWeather>(cityWeather.GetWeather());
            return cityWeather;
        }

    }
}
