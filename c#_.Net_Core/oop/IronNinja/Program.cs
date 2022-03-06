using System;

namespace IronNinja
{
    class Program
    {
        static void Main(string[] args)
        {
            Buffet allYouCanEat = new Buffet();
            SweetTooth sugarComa = new SweetTooth();
            SpiceHound hotster = new SpiceHound();

            while(!sugarComa.IsFull) {
                sugarComa.Consume(allYouCanEat.Serve());
            }

            while(!hotster.IsFull) {
                hotster.Consume(allYouCanEat.Serve());
            }

            if (sugarComa.ConsumptionHistory.Count > hotster.ConsumptionHistory.Count) {
                Console.WriteLine($"SugarComa consumed the most item, and take the win with {sugarComa.ConsumptionHistory.Count}");
            }
            else {
                Console.WriteLine($"Hotster consumed the most item, and take the win with {hotster.ConsumptionHistory.Count}");
            }
        }
    }
}
