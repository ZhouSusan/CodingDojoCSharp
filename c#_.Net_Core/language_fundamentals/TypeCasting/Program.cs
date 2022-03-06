using System;

namespace TypeCasting
{
    class Program
    {
        static void Main(string[] args)
        {
            //Type Casting will build out a NEW memory space with the desired type and then attempt to convert the 
            //previous value to this new specified type
            //The value stored can conform to the new type- for type casting to occur

            //Implicit Casting
            //-allows us to diretly convert a variable from one type to another as long as the conversion doesnt include any lost info
            //This is valid when  casting numerical value, specially values lower precison to higher precision
            //But going from higher precision to lower precision will give an error
            int IntegerValue = 65;
            double DoubleValue = IntegerValue;

            //Explicit Casting
            //-to cast from a higher to lower precision, there would be a loss of info
            double DoubleValue2 = 3.14159265358;
            int IntegerValue2 = (int)DoubleValue2;

            double floatNum = 7.76;
            //int num = floatNum; //This will cause complier type-mismatch error!!

            //int num = (int)floatNum; //Floating point to integer conversion truncates all numbers after the decimal- num is elevated to 7

            //int num = (int)"24";// Strings cannot be type case to int
            
            //-> if you wanted to do this, a ,ethod would be needed to remove the data stored in the type's
            //memeory space and reformat it for storage as the new type
            //Strings are commonly re-define methods called ToString() already exists for all variables to convert them into strings
            //Strings themeselves have amny predefined methods for returning different data-types
            int num = 7;
            string numAsString = num.ToString();//Evaluates as "7
        }
    }
}
