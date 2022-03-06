using System;

namespace Functions
{
    class Program
    {
        static void Main(string[] args)
        {
            //Functions
            //-a block of code we can execute by invoking it
            //-A function is invoked when we call its name and pass along the ncessary input
            //-Invoking, or calling, a function will execute the block of code and ususally give us back some kind of output
            //-some functions takes no input or have no output
            sayHello();
            sayHello("Andrew");
            //Static - this is a keyword that controls how we can invoke a function in our code
            //-a static function can be called within the scope of its definition or by calling it on the class it is defined
            //In an non-static method, it has to be called on an instanc eof an object

            //Invoking as Function
            //-Functions must be placed outside of the Main method, bt still inside the program
            //-C# can only see other code within the same class by default and does not support embedding of functions
            //-Once built, the new function can be run by calling its name inside the Main function and passing the necessary input

            //Function Parameters 
            //declaring parameters - defines what kind of input is passed in
            // sayHelloAgain();
            // sayHelloAgain("Yoga");

            //Return 
            //Void is a keyword that signifies that the function has no return 
            string greeting;
            greeting = sayHelloAgain();
            Console.WriteLine(greeting);
        }
        public static void sayHello() { //this function is a static member, oublic
                Console.WriteLine("Hello How are you doing today?");
            }   

        //We defined parameters in the function
        //We pass in arugments into functions
        public static void sayHello(string firstName) {
            Console.WriteLine($"Hello, {firstName}, how are you doing today?");
        }

        //Default Parameter Values 
        public static string sayHelloAgain(string firstName = "buddy") {
            return $"Hello, {firstName}";
        }
        //we can call it without providing any arugments and the default value will be used...syaHelloAgain()
        //or we can tell it with an airgment and that aurgment will be used sayHelloAgain("Yoda")
    }
}
