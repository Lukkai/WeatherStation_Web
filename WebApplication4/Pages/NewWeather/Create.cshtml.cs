using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication4.Data;
using WebApplication4.Models;
using Newtonsoft.Json;

namespace WebApplication4.Pages.NewWeather
{
    public class CreateModel : PageModel
    {
        private readonly WebApplication4.Data.WebApplication4Context _context;

        public CreateModel(WebApplication4.Data.WebApplication4Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public string Name { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            NewCityWeather newWeather = new NewCityWeather();
            CityWeather weather = new CityWeather();
            CityWeather deserializedProduct = JsonConvert.DeserializeObject<CityWeather>(weather.GetWeather(Name));
            
            newWeather.Name = deserializedProduct.Name;
            newWeather.temp = (deserializedProduct.Main.temp - 273.15f).ToString("0.00") + " *C";
            newWeather.speed = (deserializedProduct.Wind.speed).ToString("0.00") + " mps";
            
            _context.NewCityWeather.Add(newWeather);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
