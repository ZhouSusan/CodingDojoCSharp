using System;

using System.Collections.Generic;

namespace IronNinja
{
    public class Buffet
    {
        public List <IConsumable> Menu;

        public Buffet() {
            Menu = new List<IConsumable>() {
                new Food("Ice Cream", 1000, false, true),
                new Food("Bacon Burger", 1900, false, false),
                new Food("Fried Rice", 1100, true, false),
                new Food("Cheese Fries", 1400, true, false),
                new Food("spicy candy", 100, true, true),
                new Food("tamala", 990, true, false),
                new Food("Turkey Sub", 880, false, false),
                new Food("Coke", 80, false, false),
                new Food("Strawberry Lemonade", 90, false, true),
                new Food("Red wine", 100, false, false),
                new Food("Watermelon Smoothie", 130, false, true)
            };
        }
        public IConsumable Serve() {
            Random rand = new Random();
            int idx = rand.Next(Menu.Count);
            return Menu[idx];
        }
    }
}