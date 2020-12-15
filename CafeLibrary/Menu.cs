using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeLibrary
{
    public class Menu
    {
        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string Desc { get; set; }
        public string Ingredients { get; set; }
        public double Price { get; set; }

        public Menu() { }

        public Menu(int mealNumber, string mealName, string desc, string ingredients, double price)
        {
            MealNumber = mealNumber;
            MealName = mealName;
            Desc = desc;
            Ingredients = ingredients;
            Price = price;

        }
           
    }
}
