using System;
using System.Collections.Generic;

namespace HungryNinja
{
    public class Buffet
    {
        public List <Food> Menu;

        public Buffet() {
            Menu = new List<Food>() {
                new Food("Ice Cream", 1000, false, true),
                new Food("Bacon Burger", 1900, false, false),
                new Food("Fried Rice", 1100, true, false),
                new Food("Cheese Fries", 1400, true, false),
                new Food("spicy candy", 100, true, true),
                new Food("tamala", 990, true, false),
                new Food("Turkey Sub", 880, false, false)
            };
        }
        public Food Serve() {
            Random rand = new Random();
            int idx = rand.Next(Menu.Count);
            return Menu[idx];
        }
    }
}