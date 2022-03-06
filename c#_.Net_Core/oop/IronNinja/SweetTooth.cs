using System;

namespace IronNinja
{
    class SweetTooth : Ninja
    {
        public override bool IsFull {
            get {
                if (CalorieIntake < 1500) {
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
            }
            int foodCarbs = 0;
            if (item.IsSweet) {
                foodCarbs += item.Calories + 10;
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