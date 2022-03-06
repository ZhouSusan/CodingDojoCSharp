using System;
using System.Collections.Generic;

namespace Dictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> profile = new Dictionary<string, string>();
            //Almosr all the methods that exts in List are the same with DIctionaries 
            profile.Add("Name", "Sperous");
            profile.Add("Language", "PHP");
            profile.Add("Location", "Greece");
            Console.WriteLine("Instructor Profile");
            Console.WriteLine("Name - " + profile["Name"]);
            Console.WriteLine("From - " + profile["Location"]);
            Console.WriteLine("Favorite Language - " + profile["Language"]);

            foreach (KeyValuePair<string,string> entry in profile) {
                Console.WriteLine(entry.Key + "-" + entry.Value);
            }

            //type interference allows us to not have to direct type the type for the variable, but rather will cause
            //the complier to infer what the type will be based on the very first assigned to it
            //downside - greatly reduce clarity that specifies types provides
            //It is to be used sparingly when the type of a variable can easily be deduced 

            //the var key word tajes place of a type in type-inference
            foreach (var entry in profile) {
                Console.WriteLine(entry.Key + "-" + entry.Value);
            }

        }
    }
}
