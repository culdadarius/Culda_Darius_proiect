using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Culda_Darius_Proiect.Models;

namespace Culda_Darius_Proiect.Data
{
    public class Culda_Darius_ProiectContext : DbContext
    {
        public Culda_Darius_ProiectContext (DbContextOptions<Culda_Darius_ProiectContext> options)
            : base(options)
        {
        }

        public DbSet<Culda_Darius_Proiect.Models.Drink> Drink { get; set; }

        public DbSet<Culda_Darius_Proiect.Models.Category> Category { get; set; }

        public DbSet<Culda_Darius_Proiect.Models.Store> Store { get; set; }
    }
}
