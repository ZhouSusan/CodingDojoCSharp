public class Vechicle {
    //Accessibility of class members is defualted to private so we must add the public key to anything 
    //we want to allow outside access to. 

    //If we wanted to pass a vairable to this object when creating it to se some of its data memebers,
    //such as the NumPassenger field, we need to include a function inside the class called a constructor
    //Constructors are functions that exist to "construct" instance of a class
    //A constuctor is called the moment of the object is being created using the new keyword 
    //and just requires adding a function with the same name as of the class
    //this unassigned integer will default to 0
    public int NumPassengers;
    public Vechicle(int val) {//constuctor does't need a return type or the static keyword
        NumPassengers = val;
    }
    //if we want all instances of our class to have some inital values, we can achieve this by providing 
    //a constructor that takes no arugments, but initializes values with in the Constructor body
    public Vechicle() {
        NumPassengers = 5;
    }
}