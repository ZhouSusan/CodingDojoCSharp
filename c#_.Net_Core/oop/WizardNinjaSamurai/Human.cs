using System;

namespace WizardNinjaSamurai
{
    public class Human
    {
        public string Name;
        public int Strength;
        public int Intelligence;
        public int Dexerity;
        private int health;

        public int Health {
            get {
                return health;
            }
            set {
                ;
            }
        }

        public Human(string name) {
            Name = name;
            Strength = 3;
            Intelligence = 3;
            Dexerity = 3; 
            health = 100;
        }

        public Human(string name, int str, int intel, int dex, int hp) {
            Name = name;
            Strength = str;
            Intelligence = intel;
            Dexerity = dex;
            health = hp;
        }

        public virtual int Attack(Human target) {
            int dmg= Strength * 5;
            target.health -= dmg;
            Console.WriteLine($"{Name} attacked {target.Name} for {dmg} damage!");
            return target.health;
        }
    }
}