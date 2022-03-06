using System;

namespace Human
{
    class Program
    {
        static void Main(string[] args)
        {
            Human jack = new Human("Jack");
            Human juile = new Human("Juile", 5, 5, 7, 90);
            Console.WriteLine(jack);
            Console.WriteLine(juile);
            juile.Attack(jack);
            Console.WriteLine($"Jack's new health is {jack.Health}");

        }
    }
}
