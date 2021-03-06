using System;

namespace MultiDimArr
{
    class Program
    {
        static void Main(string[] args)
        {
            //Multidimensional array declaration 
            //This examples contiains 3 arrays- each of these is length 2- all inititalized to zeros. 
            int [,] array2D = new int[3, 2];
            //This is equal to : int[i] array2D = new int[3, 2] {{0, 0}, {0, 0}, {0, 0}}

            //This example has 2 large rows that each contains 3 arays == and each of those arrays is length 4
            int[,,] array3D = new int[2, 3, 4] 
            {
                {{45, 1, 16, 17}, {4, 47, 21, 68}, {21, 28, 32, 76}},
                {{11, 0, 85, 42}, {9, 10, 14, 96}, {66, 99, 33, 12}}
            };
            Console.WriteLine(array2D[0, 1]);
            Console.WriteLine(array3D[1, 0, 3]);

            //MultiArrays require they are perfect rectangular, with all inner arrays having the same length 

            //Jagged Arrays 
            //Through initialized and accessed differently, jagged arrs hold arrays but without a need of iniform inner array sizez
            //Jagged array declaration
            int[][] jaggedArray = new int[3][];
            jaggedArray[0] = new int[5];
            jaggedArray[1] = new int[4];
            jaggedArray[2] = new int[2];
            int[][] jaggedArray2 = new int[][] {
                new int[] {1, 3, 5 ,7, 9},
                new int[] {0, 2},
                new int[] {11, 22, 33, 44}
            };
            //Short-hand form
            int[][] jaggedArray3 = {
                new int[] {1, 3, 5, 7, 9},
                new int[] {0, 2},
                new int[] {11, 22, 33, 44}
            };
            //You can even mixed jagged and muli-dimensional arrays
            int[][,] jaggedArray4 = new int[3][,]
            {
                new int[,] {{1, 3}, {5, 7}},
                new int[,] {{0, 2}, {4, 6}, {8 , 10}},
                new int[,] {{11, 22}, {99, 88}, {0, 9}}
            };
            //looping through an array
            foreach( int[] innerArr in jaggedArray) {
                Console.WriteLine("Inner array length is {0}", innerArr.Length);
            }
            //Accessing a jagged array
            Console.WriteLine(jaggedArray2[0][1]);
            Console.WriteLine(jaggedArray3[2][3]);
        }
    }
}
