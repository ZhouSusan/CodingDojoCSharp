using System;
using System.Collections.Generic;

namespace Boxing_Unboxing
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create an empty List of type object
            List<object> BoxedList = new List<object>();
            //Add the following values to the list: 7, 28, -1, true, "chair"
            BoxedList.Add(7);
            BoxedList.Add(28);
            BoxedList.Add(-1);
            BoxedList.Add(true);
            BoxedList.Add("chair");
            //Loop through the list and print all values   
            //Add all values that are Int type together and output the sum
            int sum = 0;
            for (int i = 0; i < BoxedList.Count; i++) {
                //the simplest was is to make sure the value works for the type you are trying to cast it beforeing doing so.
                //This can be done by leveraging the is keyword in a conditoonal statement
                //The is keyword that allows us to discern what the real type of an object is when we unbox it, but to trat it actually treat it as that type we will need to cast it
                //unboxing casting doesn't create a new momry space. but it changes how the system references the object 
                //We also have the abiliy to use another form of casting called safe explicit casting  
                if (BoxedList[i] is int) {
                    sum += (int)BoxedList[i];
                }
                Console.WriteLine(BoxedList[i]);
            }
            Console.WriteLine($"The sum is {sum}.");
        }
    }
}

 //Safe Explicit Casting
    //-use the as keyword 
    //-unlike explicit casting, if the safe cost fails it will simply return a null value
    //-it will not throw an expection 
    //-the catch is that safe casts can on;y be used to cast a nullable tyoe
    //some simple datatypes, like int are non-nullable (they can't store null values)- cant be used for safe casting
    
    //object ActaullyString == "a string";
    //string ExplicitString = ActuallyString as string;

    //this wont work
    //object ActuallyInt = 256;
    //int ExplicitInt = Actually as int' 