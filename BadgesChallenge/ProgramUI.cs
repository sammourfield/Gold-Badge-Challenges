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
        Dictionary<string, List<string>> badgeDictionary = new Dictionary<string, List<string>>();

        

        public void Run()
        {
            List<string> list1 = new List<string>{"one", "Two", "Three" };
            badgeDictionary.Add("123", list1);
            List<string> list2 = new List<string> { "seven", "eIght", "nIne" };
            badgeDictionary.Add("789", list2);

            Menu();
        }

        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Hello Security Admin, What would you like to do?:\n" +
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
            List<string> doorsToAdd = new List<string>();

            Console.WriteLine("What Is the Number on the Badge:");
            string badgeID = Console.ReadLine();
            

            //call door method 
            doorsToAdd = AddDoorToList(doorsToAdd);
            badgeDictionary.Add(badgeID, doorsToAdd);
            Menu();
        }

     

        private List<string> AddDoorToList(List<string> doorsToAdd)
        {
            Console.WriteLine("List A door it needs access to:");
            string doorName = Console.ReadLine();
            doorsToAdd.Add(doorName);

            Console.WriteLine("Any other doors?Y/N:");
            
            string moreDoors = Console.ReadLine();
            if (moreDoors == "Y")
            {
                AddDoorToList(doorsToAdd);
            }
            return doorsToAdd;
        }
        
        private void EditABadge()
        {
            Console.WriteLine("What is the badge number to update");
            string badgeId = Console.ReadLine();
            Console.WriteLine(badgeId + " has access to " + String.Join(",", badgeDictionary[badgeId])); 

            Console.WriteLine("What would you like to do\n" +
                "1. Remove a Door\n" +
                "2. Add a Door ");
            //tell them options
            string input = Console.ReadLine();
            if (input == "1")
            {
                RemoveDoorFromBadgeDictionary(badgeId);
                //remove a door
            }
            if (input == "2")
            {
                AddDoorToBadgeDictionary(badgeId); 
                //adding a door
            }
            Console.WriteLine(badgeId + " has access to " + String.Join(",", badgeDictionary[badgeId]));
        }

        private void RemoveDoorFromBadgeDictionary(string badgeId)
        {
            var listOfDoors = badgeDictionary[badgeId];
            Console.WriteLine("What door do you want to remove?");
            string doorName = Console.ReadLine();
            listOfDoors.Remove(doorName);
            badgeDictionary[badgeId] = listOfDoors;
            
        }

        private void AddDoorToBadgeDictionary(string badgeId)
        {
            var listOfDoors = badgeDictionary[badgeId];
            Console.WriteLine("What door do you want to add?");
            string doorName = Console.ReadLine();
            listOfDoors.Add(doorName);
            badgeDictionary.Remove(badgeId);
            badgeDictionary.Add(badgeId, listOfDoors);
        }

        private void ListAllBadges()
        {
            Console.Clear();
            Console.WriteLine("Badge# \t Door Access");
            foreach (KeyValuePair<string, List<string>> kvp in badgeDictionary)
            {
                Console.WriteLine(kvp.Key.ToString()+"   "+String.Join(",", kvp.Value));
            }
        }
    }
}
