using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication4.Data;
using WebApplication4.Models;

namespace WebApplication4.Pages.NewWeather
{
    public class EditModel : PageModel
    {
        private readonly WebApplication4.Data.WebApplication4Context _context;

        public EditModel(WebApplication4.Data.WebApplication4Context context)
        {
            _context = context;
        }

        [BindProperty]
        public NewCityWeather NewCityWeather { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            NewCityWeather = await _context.NewCityWeather.FirstOrDefaultAsync(m => m.ID == id);

            if (NewCityWeather == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(NewCityWeather).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NewCityWeatherExists(NewCityWeather.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool NewCityWeatherExists(int id)
        {
            return _context.NewCityWeather.Any(e => e.ID == id);
        }
    }
}
