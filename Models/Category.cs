using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Culda_Darius_Proiect.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string CategoryName { get; set; }
        public ICollection<DrinkCategory> DrinkCategories { get; set; }
    }
}
