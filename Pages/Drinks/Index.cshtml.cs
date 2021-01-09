using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Culda_Darius_Proiect.Data;
using Culda_Darius_Proiect.Models;

namespace Culda_Darius_Proiect.Pages.Drinks
{
    public class IndexModel : PageModel
    {
        private readonly Culda_Darius_Proiect.Data.Culda_Darius_ProiectContext _context;

        public IndexModel(Culda_Darius_Proiect.Data.Culda_Darius_ProiectContext context)
        {
            _context = context;
        }

        public IList<Drink> Drink { get;set; }
        public DrinkData DrinkD { get; set; }
        public int DrinkID { get; set; }
        public int CategoryID { get; set; }


        public async Task OnGetAsync(int ? id,int ? categoryID)
        {
            Drink = await _context.Drink.Include(b => b.Store).ToListAsync();
            DrinkD = new DrinkData();
            DrinkD.Drinks = await _context.Drink
                .Include(b => b.Store)
                .Include(b => b.DrinkCategories)
                .ThenInclude(b => b.Category)
                .AsNoTracking()
                .OrderBy(b => b.Name)
                .ToListAsync();

            if (id != null)
            {
                DrinkID = id.Value;
                Drink drink = DrinkD.Drinks.Where(i => i.ID == id.Value).Single();
                DrinkD.Catetegories = drink.DrinkCategories.Select(S => S.Category);
            }
        }
    }
}
