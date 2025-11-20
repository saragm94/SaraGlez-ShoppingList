using SaraGlez_ShoppingList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaraGlez_ShoppingList.Services
{
    public class BasketSelector
    {
        private const double MaxBasketWeight = 20.0;

        public List<Item> SelectItems(List<Item> shoppingList)
        {
            var selectedItems = new List<Item>();
            double currentWeight = 0;

            //Order by weight.
            var ordered = shoppingList
                .OrderByDescending(i => i.Weight)
                .ToList();

            //We check all the list to get the correct order.
            foreach (var item in ordered)
            {
                if (currentWeight + item.Weight <= MaxBasketWeight) //Control to not pass 20kg.
                {
                    selectedItems.Add(item);
                    currentWeight += item.Weight;
                }
            }

            return selectedItems;
        }
    }
}
