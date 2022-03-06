using System;

namespace WizardNinjaSamurai
{
    public class Ninja : Human
    {
        public Ninja(string name) : base(name) {
            Dexerity = 175;
        }

        public override int Attack(Human target) {
            Random rand = new Random();
            int dmg = 5 * Dexerity;
            if (rand.Next(10) < 2) {
                target.Health -= (10 + dmg);
                Console.WriteLine($"{Name} attacked {target.Name} for {dmg} damage.");
            } else {
                target.Health -= dmg;
                Console.WriteLine($"{Name} attacked {target.Name} for {dmg} damage.");
            }
            return target.Health;
        }
           public int Steal(Human target) {
            target.Health -= 5;
            this.Health += 5;
            return target.Health;
        }
    }
}