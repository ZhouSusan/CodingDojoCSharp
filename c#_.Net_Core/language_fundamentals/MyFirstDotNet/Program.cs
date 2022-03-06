using System;

namespace FyFirstDotNet
{
    class Program
    {
        static void Main(string[] args)
        {
            string place = "Coding Dojo";
            Console.WriteLine($"Hello {place}");
            Console.WriteLine(args);
            //["Hello", "Hi", "Whatever"]

            int numRings = 5;
            int numOfAllStarAppearences = 17;
            if (numRings >= 5 || numOfAllStarAppearences > 3) {
                Console.WriteLine("Welcome, you are truly a legend");
            } 

            bool crazy= false;
            if (!crazy) {
                Console.WriteLine("Let's party!");
            }
        }
    }
}
