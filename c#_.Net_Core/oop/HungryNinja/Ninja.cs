using System;
using System.Collections.Generic;

namespace HungryNinja
{
    public class Ninja
    {
        private int calorieIntake;
        public List<Food> FoodHistory;

        //constructor 
        public Ninja () {
            calorieIntake = 0;
            FoodHistory = new List<Food>();
        }

        //getter
        public bool is_full {
            get { 
                if (calorieIntake > 1200) {
                    return true;
                }
                return false;
            }
        }
        public void Eat(Food item) {
            if (!is_full) {
                this.calorieIntake += item.Calories;
                FoodHistory.Add(item);
                Console.Write($"The food name is {item.Name}. This meal is {item.IsSpicy} spicy and {item.IsSweet} sweet.");
            }

            if (is_full) {
                Console.WriteLine("You are way too full. Please take a break, and come back later");
            }
        }
    }
}