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
    public class DeleteModel : PageModel
    {
        private readonly WebApplication4.Data.WebApplication4Context _context;

        public DeleteModel(WebApplication4.Data.WebApplication4Context context)
        {
            _context = context;
        }

        [BindProperty]
        public CityWeather CityWeather { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CityWeather = await _context.CityWeather.FirstOrDefaultAsync(m => m.ID == id);

            if (CityWeather == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            CityWeather = await _context.CityWeather.FindAsync(id);

            if (CityWeather != null)
            {
                _context.CityWeather.Remove(CityWeather);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
