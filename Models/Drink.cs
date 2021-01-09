using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Culda_Darius_Proiect.Models
{
    public class Drink
    {
        public int ID { get; set; }
        [Required,StringLength(150,MinimumLength =3)]
        

        [Display(Name="Name Of The Drink")]

        public string Name { get; set; }
        [RegularExpression(@"^[A-Z][a-z]+$"),Required,StringLength(50,MinimumLength =3)]
        public string Company { get; set; }
        [Range(1,300)]
        [Column(TypeName ="decimal(6,2)")]
        public decimal Price { get; set; }

        [DataType(DataType.Date)]
        public DateTime ExpiringDate { get; set; }

        public int StoreID { get; set; }
        public Store Store { get; set; }

        public ICollection<DrinkCategory> DrinkCategories { get; set; }
    }
}
