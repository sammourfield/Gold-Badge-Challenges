using CafeLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadgeChallenges
{
    class ProgramUI
    {
        private MenuRepo _menuRepo = new MenuRepo();

        public void Run()
        {
            SeedItemList();
            OptionList();
        }

        private void OptionList()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Select an option:\n" +
                    "1. Add New Menu Item\n" +
                    "2. View Current Menu\n" +
                    "3. View Item by Name\n" +
                    "4. Update Existing Menu Item\n" +
                    "5. Delete Existing Menu Item\n" +
                    "6. Exit." );

                string input = Console.ReadLine();
                int inputAsInt = int.Parse(input);

                switch (input)
                {
                    case "1":
                        AddNewMenuItem();
                        break;
                    case "2":
                        ViewCurrentMenu();
                        break;
                    case "3":
                        ViewItemByName();
                        break;
                    case "4":
                        UpdateMenuItem();
                        break;
                    case "5":
                        RemoveItemFromMenu();
                        break;
                    case "6":
                        Console.WriteLine("Have a Good Day!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid #.");
                        break;
                }

                Console.WriteLine("Press any Key to continue..");
                Console.ReadKey();
                Console.Clear();   
            }
        }

        private void AddNewMenuItem()
        {
            Console.Clear();
            Menu newItem = new Menu();

            Console.WriteLine("What Number will this Item be on the menu?:");
                string inputAsString = Console.ReadLine();
            newItem.MealNumber = int.Parse(inputAsString);

            
            Console.WriteLine("Enter the name of the item you are adding to the menu:");
            newItem.MealName = Console.ReadLine();

            Console.WriteLine("Enter the description of new menu item:");
            newItem.Desc = Console.ReadLine();

            Console.WriteLine("Enter the ingredients of the new menu item:");
            newItem.Ingredients = Console.ReadLine();

            Console.WriteLine("Enter the Price of the new menu item:");
            string priceAsString = Console.ReadLine();
            newItem.Price = double.Parse(priceAsString);

            _menuRepo.AddItemToMenu(newItem);


        }

        private void ViewCurrentMenu()
        {
            Console.Clear();
            List<Menu> menuList = _menuRepo.GetMenuList();

            foreach(Menu item in menuList)
            {
                Console.WriteLine($"Menu #: {item.MealNumber}\n" +
                    $"Item Name: {item.MealName}\n" +
                    $"Item Description: {item.Desc}");
            }
        }

        private void ViewItemByName()
        {
            Console.Clear();
            Console.WriteLine("Enter the name of the item you'd like to view:");

            string mealName = Console.ReadLine();

            Menu item = _menuRepo.GetItemByName(mealName);

            if(item != null)
            {
                Console.WriteLine($"Menu #: {item.MealNumber}\n" +
                    $"Item Name: {item.MealName}\n" +
                    $"Description: {item.Desc}\n" +
                    $"Ingriedents: {item.Ingredients}\n" +
                    $"Price: {item.Price}");
            }
            else
            {
                Console.WriteLine("No Item by that name.");
            }
        }

        private void UpdateMenuItem()
        {
            ViewCurrentMenu();
            Console.WriteLine("Enter the name of the item you'd like to update");
            string oldName = Console.ReadLine();
            Menu newItem = new Menu();

            Console.WriteLine("Enter the Menu # for the item:");
            string inputAsString = Console.ReadLine();
            newItem.MealNumber = int.Parse(inputAsString);

            Console.WriteLine("Enter the Item Name:");
            newItem.MealName = Console.ReadLine();

            Console.WriteLine("Enter the Description of Item:");
            newItem.Desc = Console.ReadLine();

            Console.WriteLine("Enter the indgredients of the item:");
            newItem.Ingredients = Console.ReadLine();

            Console.WriteLine("Enter the price of the item");
            string priceAsString = Console.ReadLine();
            newItem.Price = double.Parse(priceAsString);

            bool wasUpdated = _menuRepo.UpdateMenuItem(oldName, newItem);
            if (wasUpdated)
            {
                Console.WriteLine("Item Successfully Updated!");
            }
            else
            {
                Console.WriteLine("Could not update content");
            }

        }

        private void RemoveItemFromMenu()
        {
            ViewCurrentMenu();
            Console.WriteLine("\nEnter the title of the item you would like to remove:");
            string input = Console.ReadLine();
            bool wasDeleted = _menuRepo.RemoveItemFromMenu(input);
            if (wasDeleted)
            {
                Console.WriteLine("The itemn was successfully removed.");
            }
            else
            {
                Console.WriteLine("The item could not be removed.");
            }
        }

        private void SeedItemList()
        {
            Menu cheeseburger = new Menu(1, "Cheeseburger", "A juicy patty topped with melted american cheese", "Beef, salt, pepper, garlic powder, american cheese", 2.99);
            Menu chickenTendies = new Menu(2, "Chicken Tendies", "All white meat chicken fried to a crispy perfection served with your choice of dipping sauce", "Chicken, flour, salt, pepper", 3.99);

            _menuRepo.AddItemToMenu(cheeseburger);
            _menuRepo.AddItemToMenu(chickenTendies);
        }
    }
}
