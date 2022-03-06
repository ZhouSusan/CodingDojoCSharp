using System;

namespace MultiplicationTable
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] array2D = new int[10,10];

            for (int i = 0; i < 10; i++) {
                for (int j = 0; j < 10; j++) {
                    array2D[i,j] = i+1 * j+1; 
                }
            } 

            foreach(int innerArr in array2D) {
                Console.WriteLine(innerArr);
            }
        }
    }
}
