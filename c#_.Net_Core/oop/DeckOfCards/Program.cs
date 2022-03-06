using System;

namespace DeckofCards
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck deck1 = new Deck();
            Player david = new Player("David");
            david.draw(deck1);
            david.draw(deck1);
            david.draw(deck1);
            david.draw(deck1);
            david.draw(deck1);
            david.draw(deck1);
            Console.WriteLine($"There are {david.Hand.Count} cards in your hand");
            david.withdraw(2);
            david.withdraw(2);
            Console.WriteLine($"There are now {david.Hand.Count} cards left in your hand.");
        }
    }
}
