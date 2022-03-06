using System;
using System.Collections.Generic;

namespace DeckofCards
{
    public class Player
    {
        private string Name {get; set;}

        private List<Card> hand;

        public List<Card> Hand {
            get {
                return hand;
            }
        }

        public Player(string name) {
            this.Name = name;
            this.hand = new List<Card>();
        }

        public Card draw (Deck lucky) {
            Card new1 = lucky.deal();
            hand.Add(new1);
            return new1;
        }

        public Card withdraw (int index) {
            if (hand.Count < 1) {
                return null;
            } else {
                Card discard = hand[index];
                Hand.RemoveAt(index);
                return discard;
            }
        }
    }
}