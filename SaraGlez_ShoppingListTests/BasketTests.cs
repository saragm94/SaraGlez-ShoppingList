using Microsoft.VisualStudio.TestTools.UnitTesting;
using SaraGlez_ShoppingList.Models;
using SaraGlez_ShoppingList.Services;
using System.Collections.Generic;
using System.Linq;

namespace SaraGlez_ShoppingListTests
{
    [TestClass]
    public class FinalBasketSelectorTests
    {
        [TestMethod]
        public void SelectItems_NotExceed20Kg() // Check thebasket never exceeds the 20kg limit. 
        {
            var items = new List<Item>
            {
                new Item("Watermelon", 4.7),
                new Item("Flour", 1.2),
                new Item("Rice", 2.8),
                new Item("Cat Food", 7.5),
                new Item("Chocolate Bar", 0.25),
                new Item("Coffee", 0.45),
                new Item("Apple bag", 1.35),
                new Item("Cheese", 0.95),
                new Item("Milk", 1.5),
                new Item("Yogurt Tray", 1.6)
            };

            var selector = new BasketSelector();
            var basket = selector.SelectItems(items);

            double totalWeight = basket.Sum(i => i.Weight);

            Assert.IsLessThanOrEqualTo(20.0, totalWeight, $"Basket exceeded weight limit: {totalWeight} kg");
        }

        [TestMethod]
        public void SelectItems_HeaviestItemsFirst() //Check that prioritizes heavier items first.
        {
            var items = new List<Item>
            {
                new Item("Milk", 1.5),
                new Item("Apple bag", 1.35),
                new Item("Coffee", 0.45),
                new Item("Cat Food", 7.5),
                new Item("Watermelon", 4.7),
            };

            var selector = new BasketSelector();
            var basket = selector.SelectItems(items);

            // Assert that the heaviest two items are included
            Assert.IsTrue(basket.Any(i => i.Name == "Cat Food"),
                "Basket should contain the heaviest item: Cat Food.");

            Assert.IsTrue(basket.Any(i => i.Name == "Watermelon"),
                "Basket should contain the second heaviest item: Watermelon.");
        }

        [TestMethod]
        public void SelectItems_RemainingItems() //Check that only choose the items that fit inside the basket.
        {
            var items = new List<Item>
            {
                new Item("Water", 15.0),
                new Item("Cat Food", 7.5),
                new Item("Milk", 1.5),
                new Item("Coffee", 0.45),
            };

            var selector = new BasketSelector();
            var basket = selector.SelectItems(items);

            Assert.HasCount(3, basket);
        }

        [TestMethod]
        public void SelectItems_EmptyList() //Check that can return empty.
        {
            var selector = new BasketSelector();
            var basket = selector.SelectItems(new List<Item>());

            Assert.IsEmpty(basket);
        }
    }
}
