﻿using System;

namespace Loops
{
    class Program
    {
        static void Main(string[] args)
        {
            //loop from 1 to 5 including 5
            // for (int i = 1; i <= 5; i++) {
            //     Console.WriteLine(i);
            // }

            //loop from 1 to 5 excluding 5
            // for (int i = 1; i < 5; i++) {
            //     Console.WriteLine(i);
            // }
            // int start = 0;
            // int end = 5;
            // for (int i = start; i < end; i++ ) {
            //     Console.WriteLine(i);
            // }

            int i = 1; 
            while (i < 6) {
                Console.WriteLine(i);
                i = i + 1;
            }
        }
    }
}