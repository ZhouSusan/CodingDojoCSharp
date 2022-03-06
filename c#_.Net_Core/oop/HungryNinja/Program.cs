using System;

namespace HungryNinja
{
    class Program
    {
        static void Main(string[] args)
        {
            Buffet buffet = new Buffet();
            Ninja customer1 = new Ninja();

            while (!customer1.is_full) {
                customer1.Eat(buffet.Serve());
            }
        }
    }
}
