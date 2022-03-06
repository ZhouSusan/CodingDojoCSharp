using System;
using System.Collections.Generic;

namespace CollectionsPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            //Three basic Arrays
            //Create an array to hold integer values 0 through 9
            int[] numArr = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9};
            string[] names = {"Tim", "Martin", "Nikki", "Sara"};
            bool[] boolArr = {true, false, true, false, true, false, true, false, true, false, true, false, true, false, true, false, true, false, true, false};

            //Lists of Flavors 
            //Create a list of ice cream flavors that holds at least 5 different flavors (feel free to add more than 5!)
            List<string> flavors = new List<string>();

            flavors.Add("Vanilla");
            flavors.Add("Choclate");
            flavors.Add("Oreos");
            flavors.Add("Mountain Trail");
            flavors.Add("Strawberries");
            flavors.Add("Carmel Swirls");
            flavors.Add("Cookies n' Creme");
        

        //Output the length of this list after building it
        Console.WriteLine($"The current count is {flavors.Count}");

        //Output the third flavor in the list, then remove this value
        Console.WriteLine("The third flavor is " + flavors[2]);
        flavors.Remove(flavors[2]);

        //Output the new length of the list (It should just be one fewer!)
        Console.WriteLine("The update count is for this list is " + flavors.Count);

        //User Info Dictionary
        //Create a dictionary that will store both string keys as well as string values
        Dictionary<string, string> profile = new Dictionary<string, string>();
        //Add key/value pairs to this dictionary where:
        //each key is a name from your names array
        //each value is a randomly select a flavor from your flavors list.
        Random rand = new Random();        
        foreach(String name in names) {
            profile.Add(name, flavors[rand.Next(0, flavors.Count-1)]);
        }
        //Loop through the dictionary and print out each user's name and their associated ice cream flavor
        foreach (KeyValuePair<string, string> entry in profile) {
            Console.WriteLine(entry.Key + '-' + entry.Value);
        }
        }  
    }
}
