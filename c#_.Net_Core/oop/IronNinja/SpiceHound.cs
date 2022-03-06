using System;

namespace IronNinja
{
    class SpiceHound : Ninja
    {
        public override bool IsFull {
            get {
                if (CalorieIntake < 1200) {
                    return false;
                } 
                else {
                    return true;
                }
            }
        }
        
        public override void Consume(IConsumable item)
        {
            if (IsFull) {
                Console.WriteLine("You are too full to eat anymore!");
            } else {
                int foodCarbs = 0;
                if (item.IsSpicy) {
                    foodCarbs += item.Calories + 5;
                    CalorieIntake += foodCarbs;
                }
                else  {
                    foodCarbs += item.Calories;
                    CalorieIntake += foodCarbs;
                }
                ConsumptionHistory.Add(item);
                item.GetInfo();
            }
        }
    }
}