using System;

namespace RandomValue
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            //To generate 10 random values between 2 and 8 (2 inclusive, 8 exclusive), we can call .Next(2,8) in a for loop
            for (int val = 0; val < 10; val++) {
                Console.WriteLine(rand.Next(2,8));
            }
        }
    }
}
