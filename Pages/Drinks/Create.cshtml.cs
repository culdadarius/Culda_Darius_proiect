using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Culda_Darius_Proiect.Data;
using Culda_Darius_Proiect.Models;

namespace Culda_Darius_Proiect.Pages.Drinks
{
    public class CreateModel : DrinkCategoriesPageModel
    {
        private readonly Culda_Darius_Proiect.Data.Culda_Darius_ProiectContext _context;

        public CreateModel(Culda_Darius_Proiect.Data.Culda_Darius_ProiectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["StoreID"] = new SelectList(_context.Set<Store>(), "ID", "StoreName");
            var drink = new Drink();
            drink.DrinkCategories = new List<DrinkCategory>();
            PopulateAssignedCategoryData(_context, drink);
            return Page();
        }

        [BindProperty]
        public Drink Drink { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newDrink = new Drink();
            if(selectedCategories != null)
            {
                newDrink.DrinkCategories = new List<DrinkCategory>();
                foreach(var cat in selectedCategories)
                {
                    var catToAdd = new DrinkCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newDrink.DrinkCategories.Add(catToAdd);
                }
            }
            if(await TryUpdateModelAsync<Drink>(newDrink,"Drink",i => i.Name, i => i.Company, i => i.Price, i => i.ExpiringDate, i => i.StoreID)){
                _context.Drink.Add(newDrink);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedCategoryData(_context, newDrink);
            return Page();
        }
    }
}
