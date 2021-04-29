using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Net;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApplication4.Models
{
    
    public class MainWeather
    {
        public int ID{set; get;}
        public float temp { set; get; }
        public float feels_like { set; get; }
        public float temp_min { set; get; }
        public float temp_max { set; get; }
        public int pressure { set; get; }
        public int humidity { set; get; }
    }


    public class Wind
    {
        public int ID {set; get;}
        public float speed { set; get; }
        public float deg { set; get; }
    }

    public class CityWeather
    {
        public int ID { set; get; }
        public string Name { set; get; }
        //[EntityTypeBuilder.Ignore]
        public MainWeather Main { set; get; }
        //[EntityTypeBuilder.Ignore]
        public Wind Wind { set; get; }


        public string GetWeather()
        {
            using (WebClient webClient = new WebClient())
            {
                string call = string.Format("https://api.openweathermap.org/data/2.5/weather?q=" + Name + "&appid=9e78fe82c3c763872a651f2affb0f808");
                var json = webClient.DownloadString(call);
                return json;
            }


        }
    }
}