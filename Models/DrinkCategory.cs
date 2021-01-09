using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Culda_Darius_Proiect.Models
{
    public class DrinkCategory
    {
        public int ID { get; set; }
        public int DrinkID { get; set; }
        public Drink Drink { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
