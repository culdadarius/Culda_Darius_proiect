using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Culda_Darius_Proiect.Data;

namespace Culda_Darius_Proiect.Models
{
    public class DrinkCategoriesPageModel:PageModel
    {
        public List<AssignedCategoryData> AssignedCategoryDataList;

        public void PopulateAssignedCategoryData(Culda_Darius_ProiectContext context,Drink drink)
        {
            var allCategories = context.Category;
            var drinkCategories = new HashSet<int>(drink.DrinkCategories.Select(c => c.DrinkID));
            AssignedCategoryDataList = new List<AssignedCategoryData>();
            foreach(var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {
                    CategoryID = cat.ID,
                    Name = cat.CategoryName,
                    Assigned = drinkCategories.Contains(cat.ID)
                });
            }
        }
        public void UpdateDrinkCategories(Culda_Darius_ProiectContext context,string[]selectedCategories, Drink drinkToUpdate)
        {
            if(selectedCategories == null)
            {
                drinkToUpdate.DrinkCategories = new List<DrinkCategory>();
                return;
            }
            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var drinkCategories = new HashSet<int>(drinkToUpdate.DrinkCategories.Select(c => c.Category.ID));
            foreach(var cat in context.Category)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!drinkCategories.Contains(cat.ID))
                    {
                        drinkToUpdate.DrinkCategories.Add(new DrinkCategory
                        {
                            DrinkID = drinkToUpdate.ID,
                            CategoryID = cat.ID
                        });
                    }
                }
                else
                {
                    if (drinkCategories.Contains(cat.ID))
                    {
                        DrinkCategory courseToRemove = drinkToUpdate.DrinkCategories.SingleOrDefault(i => i.CategoryID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
            
        }

    }
}
