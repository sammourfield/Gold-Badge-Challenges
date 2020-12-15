using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeLibrary
{
    public class MenuRepo
    {
        private readonly List<Menu> _menuList = new List<Menu>();

        //create
        public void AddItemToMenu(Menu menuItem)
        {
            _menuList.Add(menuItem);
        }

        //read

        public List<Menu> GetMenuList()
        {
            return _menuList;
        }



        //update

        public bool UpdateMenuItem(string mealName, Menu newItem)
        {
            Menu oldItem = GetItemByName(mealName);

            if (oldItem != null)
            {
                oldItem.MealNumber = newItem.MealNumber;
                oldItem.MealName = newItem.MealName;
                oldItem.Desc = newItem.Desc;
                oldItem.Ingredients = newItem.Ingredients;
                oldItem.Price = newItem.Price;
                return true;
            }
            else
            {
                return false;
            }
        }


        //delete
        public bool RemoveItemFromMenu(string mealName)
        {
            Menu item = GetItemByName(mealName);
            if(item == null)
            {
                return false;
            }
            int initialCount = _menuList.Count; _menuList.Remove(item);
            if(initialCount > _menuList.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
               
        }


        public Menu GetItemByName(string mealName)
        {
            foreach (Menu item in _menuList)
            {
                if(item.MealName == mealName)
                {
                    return item;
                }
            }
            return null;
        }
    }
}
