using System;

namespace IronNinja
{
    public class Food : IConsumable
    {
        public string Name {get; set;}
        public int Calories {get; set;}
        public bool IsSpicy {get; set;}
        public bool IsSweet {get; set;}
        public string GetInfo() {
            return $"{Name} (Food). Calories: {Calories}. Spicy?: {IsSpicy}, Sweet?:{IsSweet}";
        }

        public Food(string name, int calories, bool spicy, bool sweet) {
            this.Name = name;
            this.Calories = calories;
            this.IsSpicy = spicy;
            this.IsSweet = sweet;
        }
    }
}