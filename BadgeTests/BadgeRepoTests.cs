using BadgeLibrary;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace BadgeTests
{
    [TestClass]

    public class BadgeRepoTests

    {
        private BadgeRepo _badgeRepo;
        [TestMethod]
        public void Arrange()
        {
            _badgeRepo = new BadgeRepo();
            List<string> List1 = new List<string> { "123" };
            List<string> List2 = new List<string> { "789" };

            Badge badge1 = new Badge(123, List1 );
            Badge badge2 = new Badge(789, List2);
            

            _badgeRepo.CreateNewBadge(badge1);
            _badgeRepo.CreateNewBadge(badge2);
            
            Assert.AreEqual(_badgeRepo._badgesDictionary.Count, 2);
        }
    }
}
