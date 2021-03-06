﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Culda_Darius_Proiect.Data;
using Culda_Darius_Proiect.Models;

namespace Culda_Darius_Proiect.Pages.Stores
{
    public class CreateModel : PageModel
    {
        private readonly Culda_Darius_Proiect.Data.Culda_Darius_ProiectContext _context;

        public CreateModel(Culda_Darius_Proiect.Data.Culda_Darius_ProiectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Store Store { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Store.Add(Store);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
