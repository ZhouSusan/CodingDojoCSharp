using System;
using System.Collections.Generic;
using System.Linq;

namespace DeckofCards
{
    public class Deck
    {
        private Card[] Cards {get; set;}
        private int NumberOfCards {get; set;} 

        public Deck () {
            
            this.Cards = new Card[52];
            reset();
            shuffle();
        }

        public Deck reset() {
            int index = 0;
            foreach(CardValue value in CardValue.GetValues(typeof(CardValue))) {
                if (index == this.Cards.Length) {
                        break;
                }
                foreach(Suit suit in Suit.GetValues(typeof(Suit))) {
                    if (index == Cards.Length) {
                        break;
                    }
                    Cards[index] = new Card(value, suit);
                    index++;
                }
            }
            return this;
        }
        public Deck shuffle() {
            Random rand = new Random();
            for (int i = 0; i < Cards.Length; i++) {
                int randomCard = rand.Next(Cards.Length);
                Card temp =  Cards[randomCard];
                Cards[randomCard] = Cards[Cards.Length-1];
                Cards[Cards.Length-1] = temp;
            }
            return this;
        }
        public Card deal() {
            if (Cards.Length > 0) {
                Card top = Cards[0];
                Cards = Cards.Where((item, index) => index != 0).ToArray();
                return top;
            } else {
                reset();
                return deal();
            }
        }
    }
}