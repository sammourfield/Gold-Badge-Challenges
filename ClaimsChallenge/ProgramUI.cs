using ClaimsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimsChallenge
{
    class ProgramUI
    {
        private ClaimRepo _claimRepo = new ClaimRepo();

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
                    "1. See All Claims\n" +
                    "2. Take Care of Next Claim\n" +
                    "3. Enter a New Claim\n" +
                    "4. Exit Program\n");
                    

                string input = Console.ReadLine();
                int inputAsInt = int.Parse(input);

                switch (input)
                {
                    case "1":
                        SeeAllClaims();
                        break;
                    case "2":
                        TakeCareOfNextClaim();
                        break;
                    case "3":
                        EnterNewClaim();
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

        private void EnterNewClaim()
        {
            Console.Clear();
            Claim newItem = new Claim();

            Console.WriteLine("What Is the Claim ID of this claim:");
            string inputAsString = Console.ReadLine();
            newItem.ClaimID = int.Parse(inputAsString);


            Console.WriteLine("Enter the Type of Claim this is car, home or theft:");
            string typeInputAsString = Console.ReadLine();
            switch (typeInputAsString)
            {
                case "car":
                    newItem.ClaimType = ClaimType.Car;
                    break;
                case "home":
                    newItem.ClaimType = ClaimType.Home;
                    break;
                case "theft":
                    newItem.ClaimType = ClaimType.Theft;
                    break;
                default:
                    Console.WriteLine("Please enter a valid claim type");
                    break;
                   
            }


            Console.WriteLine("Enter the description of the new claim:");
            newItem.Desc = Console.ReadLine();

            

            Console.WriteLine("Enter the Amount of the New Claim");
            string priceAsString = Console.ReadLine();
            newItem.ClaimAmount = double.Parse(priceAsString);



            Console.WriteLine("What month did this accident happen in?:");
            int accidentMonth = int.Parse(Console.ReadLine());

            Console.WriteLine("What day of the month did this accident happen on?:");
            int accidentDay = int.Parse(Console.ReadLine());

            Console.WriteLine("What year did this accident happen in?:");
            int accidentYear = int.Parse(Console.ReadLine());

            newItem.IncidentDate = new DateTime(accidentYear, accidentMonth, accidentDay);

            Console.WriteLine("What month did this claim happen in?:");
            int claimMonth = int.Parse(Console.ReadLine());

            Console.WriteLine("What day of the month did this claim happen on?:");
            int claimDay = int.Parse(Console.ReadLine());

            Console.WriteLine("What year did this claim happen in?:");
            int claimYear = int.Parse(Console.ReadLine());

            newItem.IncidentDate = new DateTime(claimYear, claimMonth, claimDay);

            Console.WriteLine("Is this a Valid Claim? (Y/N)");
            string validClaim = Console.ReadLine();
            if (validClaim == "Y")
            {
                newItem.IsValid = true;
            }
            else
            {
                newItem.IsValid = false;
            }

            _claimRepo.AddNewClaim(newItem);


        }

        private void SeeAllClaims()
        {
            Console.Clear();
            Queue<Claim> claimList = _claimRepo.GetClaimList();

            Console.WriteLine("ClaimID\tType\tDescription\tAmount\tDateOfAccident\tDateOfClaim\tIsValid" );
            foreach (Claim item in claimList)
            {
                Console.WriteLine($"{item.ClaimID}\t{item.ClaimType}\t{item.Desc}\t{item.ClaimAmount}\t{item.IncidentDate.ToString("MM/dd/y")}\t{item.DateOfClaim.ToString("MM/dd/y")}\t{item.IsValid.ToString()}");
            }
        }

        private void TakeCareOfNextClaim()
        {
            Console.Clear();
            Claim nextClaim = _claimRepo.SeeNextClaim();

            Console.WriteLine($"{nextClaim.ClaimID}\n{nextClaim.ClaimType}\n{nextClaim.Desc}\n{nextClaim.ClaimAmount}\n{nextClaim.IncidentDate}\n{nextClaim.DateOfClaim}\n{nextClaim.IsValid}");

            Console.WriteLine("Is this a Valid Claim? (Y/N)");
            string processClaim = Console.ReadLine();
            if (processClaim == "Y")
            {
                _claimRepo.RemoveNextClaim();
            }
            else
            {
                Menu();
            }




        }

   

      

        private void SeedItemList()
        {
            Claim claim1 = new Claim(1, ClaimType.Car, "Car Accident On I-70", 399.99, DateTime.Today, DateTime.Today, false);
            Claim claim2 = new Claim(2, ClaimType.Home, "Big Fire no good", 950.99, DateTime.Today, DateTime.Today, true);
            Claim claim3 = new Claim(3, ClaimType.Theft, "Thief in the night", 500.00, DateTime.Today, DateTime.Today, false);

            _claimRepo.AddNewClaim(claim1);
            _claimRepo.AddNewClaim(claim2);
            _claimRepo.AddNewClaim(claim3);
        }
    }
}

