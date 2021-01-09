using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Culda_Darius_Proiect.Data;
using Culda_Darius_Proiect.Models;

namespace Culda_Darius_Proiect.Pages.Drinks
{
    public class EditModel : DrinkCategoriesPageModel
    {
        private readonly Culda_Darius_Proiect.Data.Culda_Darius_ProiectContext _context;

        public EditModel(Culda_Darius_Proiect.Data.Culda_Darius_ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Drink Drink { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Drink = await _context.Drink
                .Include(b => b.Store)
                .Include(b => b.DrinkCategories).ThenInclude(b => b.Category)
                .AsNoTracking().FirstOrDefaultAsync(mbox => mbox.ID == id);

            if (Drink == null)
            {
                return NotFound();
            }
            PopulateAssignedCategoryData(_context, Drink);
            ViewData["StoreID"]=new SelectList(_context.Set<Store>(),"ID","StoreName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[]selectedCategories)
        {
            if (id==null)
            {
                return NotFound();
            }
            var drinkToUpdate = await _context.Drink
                .Include(i => i.Store)
                .Include(i => i.DrinkCategories)
                .ThenInclude(i => i.Category)
                .FirstOrDefaultAsync(s => s.ID == id);

            if (drinkToUpdate == null)
            {
                return NotFound();
            }
            if(await TryUpdateModelAsync<Drink>(drinkToUpdate,"Drink",i=>i.Name,i=>i.Company,i => i.Price, i => i.ExpiringDate, i => i.Store))
            {
                UpdateDrinkCategories(_context, selectedCategories, drinkToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            UpdateDrinkCategories(_context, selectedCategories, drinkToUpdate);
            PopulateAssignedCategoryData(_context, drinkToUpdate);
            return Page();
        }
       

       
    }
}
