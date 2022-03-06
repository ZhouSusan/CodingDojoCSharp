using System;


namespace AccessModifiers
{
    class Program
    {
        static void Main(string[] args)
        {
            Vehicle v = new Vehicle(5, "Green");
            Console.WriteLine(v.Color);
            Console.WriteLine(v.MaxNumPassengers);
        }
    }
}

//Access Modifiers 
//-allows for control over where ypur class memebers can be accessed- accessibilty level 

//-public- No access restriction 
//private - access restricted to own class(default for class members)
//protected- Access restricted to own class, and any child class
//internal - Accessed restricted to Assembly (essentially, your project's complied.all)


//Encapsualtion
//to hide internal implementation from outside code and to only publicly provide what is essential 
//use properties to be a public "wrapper" to our private fields
//by using only getter, we can provide a read-only access to private fields 