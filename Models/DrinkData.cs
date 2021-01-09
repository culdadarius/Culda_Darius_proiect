using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Culda_Darius_Proiect.Models
{
    public class DrinkData
    {
        public IEnumerable<Drink>Drinks{get;set;}
        public IEnumerable<Category> Catetegories { get; set; }
        public IEnumerable<DrinkCategory> DrinkCategories { get; set; }


    }
}
