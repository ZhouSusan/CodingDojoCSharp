using System;
using System.Collections.Generic;

namespace Puzzles
{
    class Program
    {
        static void Main(string[] args)
        {
            RandomArray();
            TossCoin();
            double res;
            res = TossMultipleCoins(7);
            Console.WriteLine(res);

            List<string> resName;
            resName = Names();
            Console.WriteLine(resName);
        }

        //Random Array
        public static void RandomArray() {
            Random rand = new Random();
            int[] randomArray = new int[10];
            for (int i = 0; i < 10; i++) {
                randomArray[i] = rand.Next(2, 25);
            }

            foreach(int num in randomArray) {
                Console.WriteLine(num);
            }
        }

        //Coin Flip
        public static string TossCoin() {
            Random rand = new Random();
            Console.WriteLine("Tossing a Coin!");
            string output= "";
            int res = rand.Next(0, 2);
            if (res == 0) {
                output = "Heads";
            } else {
                output = "Tails";
            }
            Console.WriteLine(output);
            return output;
        }

        //Toss Multiple Coins
        public static double TossMultipleCoins(int num) {
            double headsCount = 0;
            int start = 0;
            while (start <= num) {
                if (TossCoin() == "Heads") {
                    headsCount++;
                }
                start++;
            }
            Console.WriteLine($"Heads toss- {headsCount} : Total toss-{num}");
            return headsCount/num;
        }

        //Names
        public static List<string> Names() {
            List<string> namesList = new List<string>();
            namesList.Add("Todd");
            namesList.Add("Tiffany");
            namesList.Add("Charlie");
            namesList.Add("Geneva");
            namesList.Add("Sydney");

            Shuffle(namesList);

            var updatedNameList = filteredList(namesList);
            foreach (var val in updatedNameList) {
                Console.WriteLine(val);
            }
            return updatedNameList;
        }

        public static void Shuffle(List<string> arrList) {
            Random rand = new Random();
            int n = arrList.Count;
            while( n > 1) {
                n--;
                int k = rand.Next(0, n+1);
                string temp =  arrList[k];
                arrList[k] = arrList[n];
                arrList[n] = temp;
            }
        }

        public static List<string> filteredList(List<string> arrList) {
            var filtered = new List<string>();
            foreach (var item in arrList) {
                if (item.Length > 5) {
                    filtered.Add(item);
                }
            }
            return filtered;
        }
    }
}
