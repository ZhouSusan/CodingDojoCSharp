using System;

namespace Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            //Declaring an array of length of 5, initialized by default to all zeros
            int[] numArray = new int[5];
            //Declaring an array with pre-populated values
            //For Arrays initialized this way, the length is determined by the size of the given data
            int[] numArray2 = {1, 2, 3, 4, 4, 6};

            int[] array3;
            array3 = new int[] {1, 3, 5, 7, 9};

            int[] arrayOfInts = {1, 2, 3, 4, 5};
            Console.WriteLine(arrayOfInts[0]);
            Console.WriteLine(arrayOfInts[1]);
            Console.WriteLine(arrayOfInts[2]);
            Console.WriteLine(arrayOfInts[3]);
            Console.WriteLine(arrayOfInts[4]);

            int[] arr = {1, 2, 3, 4};
            Console.WriteLine($"The first number of the arr is {arr[0]}");
            arr[0] = 8;
            Console.WriteLine($"The first number is now {arr[0]}");

            //iterating through the array
            string[] myCars = new string[] {"Mazda Miata", "Ford Model T", "Dodge Challenger", "Nissan 300zx"};
            for (int i = 0; i < myCars.Length; i++) {
                Console.WriteLine($"I own a {myCars[i]}");
            }

            //for each loop
            string[] myCars2 = new string[] {"Mazda Miata", "Ford Model T", "Dodge Challenger", "Nissan 300zx"};
            foreach (string car in myCars2) {
                Console.WriteLine($"I own a {car}");
            }
        }
    }
}
