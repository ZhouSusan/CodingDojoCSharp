using System;

namespace ClassMembers {
    //these are examples a fields, data that lives in this class
    class Vehicle {
        int MaxNumPassengers;
        string Color; 
        double MaxSpeed; 

        void MakeNoise(string noise) {
            Console.WriteLine(noise);
        }

        void MakeNoise() { //Method overloading
            Console.WriteLine("BEEP!");
        }

        //someVehicle.ColorProp => Color
        //someVehicle.ColorProp = "Some Color" 
        string ColorProp {//You must chose to have at least 1 accessors
            get { //get is a string type methods, so must return a string within this code block
                if (Color == "Green") {
                    return $"This Sweet thing is {Color}";
                }
                return $"This thing is {Color}";
            }
            set { //void type methods, do not need to return anything, but you could use a return keywords to break out of set {}
                if (value != "Green") {
                    Color = value;
                } 
                Color = value; //value is a restricted keyword, it is whatever you assign to your field's property
            }
        }

        //auto-property
        string Name {get; set;}//this is used alot in the later framework
        //provides a backend field and it exists on a object, and on a poperty that gets auro-initialized 
        //you can assign and retrieve property here
    }
}

//Methods are just a function that we define in a class specifically 
//We can have two methods with sae name, as long we have different input of parameters

//Properties 
//-allows you to safely work with your fields members 
//Get is only a readonly of the class, it only returns a value