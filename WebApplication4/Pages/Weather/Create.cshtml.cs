﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication4.Data;
using WebApplication4.Models;

namespace WebApplication4.Pages.Weather
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

            _context.CityWeather.Add(_context.AddDataToBase(Name));
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
