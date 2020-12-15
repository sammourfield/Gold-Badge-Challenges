using System;
using ClaimsLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClaimsTest
{
    [TestClass]
    public class ClaimRepoTests
    {
        private ClaimRepo _repo;
       


        [TestMethod]
        public void Arrange()
        {
            _repo = new ClaimRepo();
            
            Claim claim1 = new Claim(1, ClaimType.Car, "Car Accident On I-70", 399.99, DateTime.Today, DateTime.Today, false);
            Claim claim2 = new Claim(2, ClaimType.Home, "Big Fire no good", 950.99, DateTime.Today, DateTime.Today, true);
            Claim claim3 = new Claim(3, ClaimType.Theft, "Thief in the night", 500.00, DateTime.Today, DateTime.Today, false);

            _repo.AddNewClaim(claim1);
            _repo.AddNewClaim(claim2);
            _repo.AddNewClaim(claim3);
            Assert.AreEqual(_repo.GetClaimList().Count, 3);
        }

        [TestMethod]

        //See Next Claim SHould Return Claim at Top of queue but shouldnt remove
        public void SeeNextClaim()
        {
            _repo = new ClaimRepo();

            Claim claim1 = new Claim(1, ClaimType.Car, "Car Accident On I-70", 399.99, DateTime.Today, DateTime.Today, false);
            Claim claim2 = new Claim(2, ClaimType.Home, "Big Fire no good", 950.99, DateTime.Today, DateTime.Today, true);
            Claim claim3 = new Claim(3, ClaimType.Theft, "Thief in the night", 500.00, DateTime.Today, DateTime.Today, false);

            _repo.AddNewClaim(claim1);
            _repo.AddNewClaim(claim2);
            _repo.AddNewClaim(claim3);
            Claim nextClaim = _repo.SeeNextClaim(); 
            //Next Claim id in queue should be 1 
            Assert.AreEqual(nextClaim.ClaimID, 1);
            //Claim list should still contain 3 items.
            Assert.AreEqual(_repo.GetClaimList().Count, 3);

        }

        [TestMethod]
        public void ProcessNextClaim()
        {
            _repo = new ClaimRepo();

            Claim claim1 = new Claim(1, ClaimType.Car, "Car Accident On I-70", 399.99, DateTime.Today, DateTime.Today, false);
            Claim claim2 = new Claim(2, ClaimType.Home, "Big Fire no good", 950.99, DateTime.Today, DateTime.Today, true);
            Claim claim3 = new Claim(3, ClaimType.Theft, "Thief in the night", 500.00, DateTime.Today, DateTime.Today, false);

            _repo.AddNewClaim(claim1);
            _repo.AddNewClaim(claim2);
            _repo.AddNewClaim(claim3);

            //Claim list should still contain 3 items.
            Assert.AreEqual(_repo.GetClaimList().Count, 3);
            //Process next claim
            _repo.RemoveNextClaim();
             //Claim list should still contain 2 items.
            Assert.AreEqual(_repo.GetClaimList().Count, 2);
        }
    }
}
