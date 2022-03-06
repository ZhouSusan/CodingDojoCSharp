using System;
using System.Collections.Generic;


//Lists are an implementation of linked lists that act very much like the dynamically sizing of the arrays
//AssemblyLoadEventArgs to add, remove,  declare size, access index
//Lists are objects with indexed attribtues that act as the values of the array
namespace Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> bikes = new List<string>();
            bikes.Add("Kawasaki");
            bikes.Add("Triumph");
            bikes.Add("BMW");
            bikes.Add("Moto Guzzi");
            bikes.Add("Harley Davidson");
            bikes.Add("Suzuki");

            Console.WriteLine(bikes[2]);//accessing an array
            Console.WriteLine($"We currently know of {bikes.Count} motorcycle manufacturers.");

            //count is the attribute for a number of items 
            Console.WriteLine("The current manufacturers we have seen are:");
            for (var idx = 0; idx < bikes.Count; idx++) {
                Console.WriteLine("-" + bikes[idx]);
            }
            //Insert a new item between a specific item
            bikes.Insert(2, "Yamaha");
            //Remove is lot like JS array pop, bt searches for a specified value
            bikes.Remove("Suzuki");
            bikes.Remove("Yamaha");
            bikes.RemoveAt(0);//RemoveAt has a no return value 
            //The updated list can he itereated using a foreach loop
            Console.WriteLine("List of Non-Japanese Manufacturers:");
            foreach (string manu in bikes) {
                Console.WriteLine("-" + manu);
            }
        }
    }
}
