using SaraGlez_ShoppingList.Models;
using SaraGlez_ShoppingList.Services;

namespace SaraGlez_ShoppingList
{
    public class Basket
    {
        public static void Main(string[] args)
        {
            //Simple list with more than 20kg
            var shoppingList = new List<Item>
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
            var remainingItems = new List<Item>(shoppingList);

            int basketNumber = 1;

            //Created to end the shopping list and buy everything.
            while (remainingItems.Count > 0)
            {
                //Created more than 1 basket to check how many times we have to go to the supermarket
                var basket = selector.SelectItems(remainingItems);

                Console.WriteLine($"----- Basket {basketNumber} -----");

                foreach (var item in basket)
                {
                    Console.WriteLine($"{item.Name} - {item.Weight} kg");
                }

                Console.WriteLine($"Total weight: {basket.Sum(i => i.Weight):0.00} kg\n");  //Kg control

                //If we’ve already bought it, we remove it from the list.
                foreach (var selected in basket)
                {
                    remainingItems.Remove(selected);
                }

                // Increase the basket count (or the supermarket trips, if we prefer to see it that way).
                basketNumber++;
            }

            Console.WriteLine("All items have been placed into baskets.");
        }
    }
}
