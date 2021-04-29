using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication4.Data;
using WebApplication4.Models;

namespace WebApplication4.Pages.Weather
{
    public class IndexModel : PageModel
    {
        private readonly WebApplication4.Data.WebApplication4Context _context;

        public IndexModel(WebApplication4.Data.WebApplication4Context context)
        {
            _context = context;
        }

        public IList<CityWeather> CityWeather { get;set; }

        public async Task OnGetAsync()
        {
            CityWeather = await _context.CityWeather.ToListAsync();
        }
    }
}
