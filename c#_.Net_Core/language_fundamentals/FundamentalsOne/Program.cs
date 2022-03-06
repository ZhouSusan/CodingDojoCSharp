using System;

namespace FundamentalsOne
{
    class Program
    {
        static void Main(string[] args)
        {
             //  If you used "for" loops for your solution, 
            //  try doing the same with "while" loops. Vice-versa if you used "while" loops!

           // Create a Loop that prints all values from 1-255
            for (int i = 1; i <= 255; i++) {
                Console.WriteLine(i);
            }

            int start = 1;
            int end = 256;
            while (start < end) {
                Console.WriteLine(start);
                start++;
            }

            //Create a new loop that prints all values from 1-100 that are divisible by 3 or 5, but not both
            int startPt = 1;
            int endPt = 100;
            while ( startPt <= endPt) {
                if (startPt % 3 == 0) {
                    Console.WriteLine(startPt);
                }
                startPt++;
            }

            for (int i = 1; i < 101; i++) {
                if (i % 5 == 0) {
                    Console.WriteLine(i);
                }
            }

            // Modify the previous loop to print "Fizz" for multiples of 3, "Buzz" for multiples of 5, 
            // and "FizzBuzz" for numbers that are multiples of both 3 and 5
            // int start = 1;
            // int end = 100;
            while (start <= end) {
                if ((start % 3 == 0) && (start % 5 == 0)) {
                    Console.WriteLine("FizzBuzz");
                } else if (start % 5 == 0) {
                    Console.WriteLine("Buzz");
                } else if (start % 3 == 0) {
                    Console.WriteLine("Fizz");
                } else {
                    Console.WriteLine(start);
                }
                start++;
            }
            
            for (int i = 1; i <= 100; i++) {
                if ((i % 3 == 0) && i % 5 == 0 ) {
                    Console.WriteLine("FizzBuzz");
                } else if (i % 5 == 0) {
                    Console.WriteLine("Buzz");
                } else if (i % 3 == 0) {
                    Console.WriteLine("Fizz");
                } else {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
