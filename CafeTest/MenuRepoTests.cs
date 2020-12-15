using System;
using CafeLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CafeTest
{
    [TestClass]
    public class MenuRepoTests
    {
        private MenuRepo _repo;
        private Menu _items;


        [TestInitialize]
        public void Arrange()
        {
            _repo = new MenuRepo();
            _items = new Menu(3, "Mac N Cheese", "Creamy goodness", "noodles, cheese", 3.66);

            _repo.AddItemToMenu(_items);

        }

        [TestMethod]

        public void AddToMenuSouldntGetNull()
        {
            Menu item = new Menu();
            item.MealName = "Brisket";
            MenuRepo repos = new MenuRepo();

            repos.AddItemToMenu(item);
            Menu itemFromDirectory = repos.GetItemByName("Brisket");

            Assert.IsNotNull(itemFromDirectory);


        }

        [TestMethod]
        public void UpdateExistingItem_ShouldBeTrue()
        {
            Menu newItem = new Menu(4, "Quesadilla", "Have a fiesta in your mouth with this south of the border classic", "chicken, beans, queso, flour, guac", 4.50);
            bool updateResult = _repo.UpdateMenuItem("Cheeseburger", newItem);

            Assert.IsTrue(updateResult);
        }

        [DataTestMethod]
        [DataRow("Cheeseburger", true)]
        [DataRow("Brisket", false)]

        public void UpdateExistingMenu_ShouldMatchBool(string originalName, bool shouldUpdate)
        {
            Menu newItem = new Menu(4, "Quesadilla", "Have a fiesta in your mouth with this south of the border classic", "chicken, beans, queso, flour, guac", 4.50);

            bool updateResult = _repo.UpdateMenuItem(originalName, newItem);

            Assert.AreEqual(shouldUpdate, updateResult);
        }

        [TestMethod]
        public void DeleteItem_ShouldReturnTrue()
        {
            bool deleteResult = _repo.RemoveItemFromMenu(_items.MealName);
            Assert.IsTrue(deleteResult);
        }
    }
}