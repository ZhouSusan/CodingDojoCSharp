using System;

namespace Inheritance
{
    public class Vehicle
    {
    public int NumPassengers;
    public string Color;
    public double Odometer;
    // Say Vechicle has two overloaded constructors
    // We will either need to pass up two values (int, string), from Car ...
    public Vehicle(int numPas, string col)
    {   
        NumPassengers = numPas;
        Color = col;
        Odometer = 0;
    }
    // Or just one string value.  
    public Vehicle(string col)
    {
        NumPassengers = 5;
        Color = col;
        Odometer = 0;
    }
    
    }
}

//The base keyword following the new class constructor is done to pass the needed variables
//to the parent class' constructor method.
//The parent class's constructor will be run, and then the child's constructor will execute 