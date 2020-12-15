using BadgeLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgesChallenge
{
    class ProgramUI
    {
        private BadgeRepo _badgeRepo = new BadgeRepo();

        public void Run()
        {
            SeedItemList();
            Menu();
        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Select an option:\n" +
                    "1. Add A Badge\n" +
                    "2. Edit A Badge\n" +
                    "3. List All Badges\n" +
                    "4. Exit Program\n");


                string input = Console.ReadLine();
                int inputAsInt = int.Parse(input);

                switch (input)
                {
                    case "1":
                        AddABadge();
                        break;
                    case "2":
                        EditABadge();
                        break;
                    case "3":
                        ListAllBadges();
                        break;
                    case "4":
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
        private void AddABadge()
        {
            Console.Clear();
            Badge newItem = new Badge();

            Console.WriteLine("What Is the Number on the Badge:");
            string badgeID = Console.ReadLine();
            newItem.BadgeID = int.Parse(badgeID);

            Console.WriteLine("List A door it needs access to:");
            string doorNames = Console.ReadLine();
            newItem.DoorNames.Add(doorNames);

            Console.WriteLine("Any other doors?:");
            string moreDoors = Console.ReadLine();
            if (moreDoors == "Y")
            {
                newItem.IsValid = true;
            }
            else
            {
                newItem.IsValid = false;
            }
        }
        
        private void EditABadge()
        {

        }

        private void ListAllBadges()
        {
            Console.Clear();
            List<int> BadgeNumbers = new List<int>();

            Console.WriteLine("Badge#\tDoor Access");
            foreach (Badge badge in badgeList)
        }
    }
}
