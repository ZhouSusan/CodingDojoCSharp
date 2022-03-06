namespace AccessModifiers
{
    public class Vehicle
    {
       private int maxNumPassengers;
        private string color;

        public int MaxNumPassengers {
            get {
                return maxNumPassengers;
            }
        }

        public string Color {
            get {
                return color;
            }
        }
        public Vehicle (int maxPass, string col) {
            maxNumPassengers = maxPass;
            color = col;
        }
    }
}

//If you do not define the accessibility level- the default is private 
//You can only refer to that member fromt hat class from which it is defined