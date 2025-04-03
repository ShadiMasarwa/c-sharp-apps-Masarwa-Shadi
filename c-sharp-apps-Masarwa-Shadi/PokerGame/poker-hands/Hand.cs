using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c_sharp_apps_Masarwa_Shadi.PokerGame.poker_hands
{
    public class Hand
    {


        //Hand h = new Hand("8C TS KC 9H 4S"); 
        public Hand(String handString)
        {
            string[] hand = handString.Split(' ');
            for (int i = 0; i < hand.Length; i++)
            {
                int num = int.Parse(hand[i].Substring(0, hand[i].Length - 1));
                char suit = hand[i].Substring(hand[i].Length - 1)[0];
                Suit s;
                switch (suit)
                {
                    case 'C':
                        s= Suit.CLUBS;
                        break;
                    case 'D':
                        s= Suit.DIAMONDS;
                        break;
                    case 'H':
                        s= Suit.HEARTS;
                        break;
                    case 'S':
                        s=Suit.SPADES;
                        break;
                    default:
                        s = Suit.CLUBS;
                        break;
                }
                cards[i] = new Card(num, s);

            }
            
        }

        public Hand()
        {



        }

        private Card[] cards = new Card[5];

        public Card[] Cards { get => cards; set => cards = value; }

        public void Sort()
        {
            Array.Sort<Card>(cards);
        }

    }
}
