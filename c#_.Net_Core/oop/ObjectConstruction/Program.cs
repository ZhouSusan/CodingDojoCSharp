using System;
using static Vechicle;

namespace ObjectConstruction
{
    class Program
    {
        static void Main(string[] args)
        {
           //OOP is a key paradigm of the c# language and is extensively used in the ASP.Net Core web-framework
           //Main focus: class creation
           //Classes define what objects we bcan build, how we interact with them, and how they themselves interact with our program 
           //Classes are a blueprint of functions and properties that we as an instance of this class, AKA an Object to hold.

            //In order to create an object of a class, we must invoke our class, we must invoke our class as a new reference object

            //Notice the type for the new object reference
            //is the same as the class namespace
            Vechicle myVehicle = new Vechicle(7);//Adding a value to the object; then passes it to the constructor
            Console.WriteLine($"My vehicle is holding {myVehicle.NumPassengers} people");
        }
    }
}
