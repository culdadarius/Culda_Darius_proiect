using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Culda_Darius_Proiect.Data;
using Culda_Darius_Proiect.Models;

namespace Culda_Darius_Proiect.Pages.Stores
{
    public class IndexModel : PageModel
    {
        private readonly Culda_Darius_Proiect.Data.Culda_Darius_ProiectContext _context;

        public IndexModel(Culda_Darius_Proiect.Data.Culda_Darius_ProiectContext context)
        {
            _context = context;
        }

        public IList<Store> Store { get;set; }

        public async Task OnGetAsync()
        {
            Store = await _context.Store.ToListAsync();
        }
    }
}
