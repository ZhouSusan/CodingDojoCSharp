namespace Human
{
    public class Human
    {
        public string Name;
        public int Strength;
        public int Intelligence;
        public int Dexterity;
        private int health;

        public int Health {
            get {
                return health;
            }
        } 

        public Human (string name) {
            this.Name = name;
            this.Strength = 3;
            this.Intelligence = 3;
            this.Dexterity = 3;
            this.health = 100;

        }

        public Human (string name, int strength, int intelligence, int dexterity, int health) {
            this.Name = name;
            this.Strength = strength;
            this.Intelligence = intelligence;
            this.Dexterity = dexterity;
            this.health = health;
        }
        public int Attack (Human target) {
            target.health -= (5*this.Strength);
            return target.health;
        }

        public override string ToString()
        {
            return $@"
                Name : {Name}
                Stength: {Strength}
                Intelligence : {Intelligence}
                Dexterity : {Dexterity}
                Health: {Health}
            ";
        }
    }
}