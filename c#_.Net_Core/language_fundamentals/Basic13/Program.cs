using System;
using System.Collections.Generic;

namespace Basic13
{
    class Program
    {
        static void Main(string[] args)
        {
            PrimeNumbers();// prints 1-255

            PrintOdds();// prints odd numbers between 1-255

            PrintSum();//prints sums

            int[] array2d = new int[] {0, 1, 2, 3, 4, 5, 6, 7, 8, 9};
            LoopArray(array2d); //Looping through array

            int max;
            max = FindMax(array2d);
            Console.WriteLine(max);
            int[] negNumsArr = new int[] {-1, -2, -3 -4, -5};
            int negMax;
            negMax = FindMax(negNumsArr);
            Console.WriteLine(negMax);
            int[] sortedNumArr = new int[] {-5, 10, 0, -10, 5};
            int sortedMax;
            sortedMax = FindMax(sortedNumArr);
            Console.WriteLine(sortedMax);

            int[] avgArr = new int[] {-1, -2, -3, 3, 2, 1, 10, 6};//2
            GetAverage(avgArr);

            OddArray();

            int[] greaterThanArray = new int[5] {10, 3, 5, 7, 9};
            int greaterThanTotal;
            greaterThanTotal = GreaterThanY(greaterThanArray, 3);
            Console.WriteLine($"There are a total of {greaterThanTotal} greater than 3.");

            int[] squareArr = new int[5] {1, 4, 10, -10, -20};
            SquareArrayValues(squareArr);

            int[] noNegatives = new int[6] {1, 5, 10, -2, 3, -1};
            EliminateNegatives(noNegatives);

            int[] arrayOne = new int[5] {1, 5, 10, -2, 1};
            MinMaxAverage(arrayOne);

            int[] shiftNumArr = new int[6] {1, 5, 10, 7, -2, -3};
            ShiftValues(shiftNumArr);

            int[] numbers = new int[4] {-2, -1, -3, 2};
            NumToString(numbers);
        }
         //1. Print 1-255
        public static void PrimeNumbers() {
            for (int i = 1; i <= 255; i++) {
                Console.WriteLine(i);
            }
        }

        //Print odd numbers between 1-255
        public static void PrintOdds() {
            for (int i = 1; i < 256; i++) {
                if (i % 2 != 0) {
                    Console.WriteLine(i);
                }
            }
        }    

        //Print Sum
        public static void PrintSum() {
            int start = 1;
            int end = 255;
            int sum = 0;
            while (start <= end) {
                sum += start;
                start++;
            }    
            Console.Write(sum);
        }

        // //Iterating through an Array
        public static void LoopArray(int[] numbers) {
            for (int i = 0; i < numbers.Length; i++) {
                Console.WriteLine(numbers[i]);
            }
        }

        //Find Max
        public static int FindMax(int[] numbers) {
            int highest = numbers[0]; 
            for (int i = 1; i < numbers.Length; i++) {
                if (numbers[i] > highest) {
                    highest = numbers[i];
                }
            }
            return highest;
        }

        //Get Average
        public static void GetAverage(int[] numbers) {
            int sum = 0; 
            double avg = 0;
            for (int i = 0; i < numbers.Length; i++) {
                sum += numbers[i];
            }
            avg = sum/numbers.Length;
            Console.WriteLine($"The average is {avg}.");
        }

        //Array with Odd Numbers- between 1 to 255
        public static int[] OddArray() {
            int[] oddNumArr = new int[128];
            for (int i = 0; i < oddNumArr.Length; i++) {
                int y = (2*i) + 1;
                oddNumArr[i] = y;
                Console.WriteLine(y);
            }
            return oddNumArr;
        }
        
        //Greater Than Y
        public static int GreaterThanY(int[] numbers, int y) {
            int greaterThanVal = 0;
            for (int i = 0; i < numbers.Length; i++) {
                if (numbers[i] > y) {
                    greaterThanVal += 1;
                }
            }
            return greaterThanVal;
        }

        //Squares the Values
        public static void SquareArrayValues(int[] numbers) {
            for (int i = 0; i < numbers.Length; i++) {
                numbers[i] = numbers[i] * numbers[i];
                Console.WriteLine(numbers[i]);
            }
        }

        //Eliminate Negaative Numbers
        public static void EliminateNegatives(int[] numbers) {
            for (int i = 0; i < numbers.Length; i++) {
                if (numbers[i] < 0) {
                    numbers[i] = 0;
                }
                Console.WriteLine(numbers[i]);
            }
        }

        //Min, Max, and Average
        public static void MinMaxAverage(int[] numbers) {
            int start = 1;
            int lowest = numbers[0];
            int highest = numbers[0];
            int sum = lowest;
            int avg = 0;

            while (start < numbers.Length) {
                if (numbers[start] < lowest) {
                    lowest = numbers[start];
                } else if (numbers[start] > highest) {
                    highest = numbers[start];
                }
                sum += numbers[start];
                Console.WriteLine("sum" + sum);
                start++;
            }
            avg = sum/numbers.Length;
            Console.WriteLine($"Min: {lowest}, Max: {highest}, Average: {avg}");
        }

        //Shifting the values in an array
        public static void ShiftValues(int[] numbers) {
            for (int i = 0; i < numbers.Length-1; i++) {
                numbers[i] = numbers[i+1];
                Console.WriteLine(numbers[i]);
            }
            numbers[numbers.Length-1] = 0;
            Console.WriteLine(numbers[numbers.Length-1]);
        }

        //Number to String
        public static object[] NumToString(int[] numbers) {
            object[] objArr = new object[numbers.Length];
            for (int i = 0; i < numbers.Length; i++) {
                if (numbers[i] < 0) {
                    objArr[i] = "Dojo";
                } else {
                    objArr[i] = numbers[i];
                }
            }
            foreach (object item in objArr) {
                Console.WriteLine(item);
            }
            return objArr;
        }   
    }
}
