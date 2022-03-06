using System;

namespace IronNinja
{
    public class Drink : IConsumable
    {
        public string Name {get; set;}
        public int Calories {get; set;}
        public bool IsSpicy {get; set;}
        public bool IsSweet {get; set;}

        //Implement a GetInfo Method
        public string GetInfo() {
            return $"{Name} (food). Calories: {Calories}. Spicy?: {IsSpicy}, Sweet?:{IsSweet}";
        }
        //Add a constructor method
        public Drink(string name, int calories, bool spicy, bool sweet) {
            this.Name = name;
            this.Calories = calories;
            this.IsSpicy = spicy;
            this.IsSweet = sweet;
        }
    }
}