using System;

namespace ClassMembers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}

//Notes: OOP 

//member - decribes anything listed within a class definition
//-there are three kinds of class members
//refers to anything you place in a class, such as compleents, anything you list in a class

//Fields
//Fields are variables that are declared within a class
//FIelds are data that lives on a object of your class
//-Data a class possesess, such as a variable 
// class Vehicle {
//     public int MaxNumPassengers;
//     public string Color;
//     public double MaxSpeed; 
//}

//Methods 
//-Methods are functions that are declared within a class
//-You must declare a return type as well as any input arugments
//Methods maybe over overloaded- you may provide more than one method at the same time
//Invocation of an overloaded method is determined by the arugment(s) you pass to the method call 
//A methods is what you defined in that class and what it does (Functions a class can perform)

// class Vehicle {
//     public void MakeNoise(string noise) {//vehicleObject.MakeNoise("HOOONK!") will invoke this one
//         Console.WriteLine(noise);
//     }

//     public void MakeNoise() {//vehicleObject.MakeNoise() will invoke this one
//         Console.Write("Beep!");
//     }
// }

//Properties 
//-are a hybrid btw fields && a method (They appear as fields, but behave like methods)
//They will work with two keywords- get/set(property accessors)
//get && set- each with separate code blocks that will either return or assign a value
//used to provide safety controls over fields
//get accessors(getters) must return a value of the type declared by the property
//set accessors(setters) make use of the value keyword which is determined byt he right-hand value of a property assignment 
//Control over how fields are retrieved/uploaded 

// class Vehicle {
//     public string ColorProp {
//         get {
//             //simply referencing the property ill invoke the "getter', such as:
//             //Console.WriteLine(vehucleObject.ColorProp) and the following will return
//             return $"This thing is {Color}";
//         }
//         set {
//             //Assign a value to a property, such as:
//             //vehicleObject.ColorProp = "Blue";
//             //will invoke the "setter", and the "value" keyword will become assigned value
//             //("blue" in this example)

//             Color = value;
//         }
//     }
// }

//Auto-Implemented Properties
//-use properties to generate fileds- by providing the get and set keywords without any code blocks 
//-this also create a so-called "backing field" for your class- which is known to your complier and hide your source code
//-used in ASP web-framework 

// class Vehicle {
//     public string Name {get; set;}
// }