using System;

namespace WizardNinjaSamurai
{
    public class Wizard : Human
    {
        private int health;
        public Wizard(string name) : base(name) {
            health = 50;
            Intelligence = 25;
        }
        
        public override int Attack(Human target) {
            int dmg = Intelligence * 5;
            target.Health -= dmg;
            Console.WriteLine($"{Name} attacked {target.Name} for {dmg} damage.");

            this.health += dmg;
            return target.Health;
        }

        public int Heal(Human target) {
            target.Health += (10 * Intelligence);
            return target.Health;
        }
    }
}