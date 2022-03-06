using System;
using System.Collections.Generic;

namespace IronNinja
{
    abstract class Ninja
    {
        protected int CalorieIntake;
        public List<IConsumable> ConsumptionHistory;
        public Ninja() {
            CalorieIntake = 0;
            ConsumptionHistory = new List<IConsumable>();
        }

        public abstract bool IsFull {get;}
        public abstract void Consume(IConsumable item);
    }
}