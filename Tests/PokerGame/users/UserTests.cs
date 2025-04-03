using Microsoft.VisualStudio.TestTools.UnitTesting;
using c_sharp_apps_Masarwa_Shadi.PokerGame.users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using c_sharp_apps_Masarwa_Shadi.PokerGame.poker_hands;

namespace MyTests
{
    [TestClass()]
    public class UserTests
    {
        [TestMethod()]
        public void MyTest1()
        {
            User user = new User("Shadi", User_Role.PLAYER);
            Assert.AreEqual("Shadi", user.Username);
        }
        [TestMethod()]
        public void MyTest2()
        {
            List<User> expected = new List<User>();
            List<User> actual = new List<User>();
            User user1 = new User("Shadi", User_Role.ADMIN);
            User user2 = new User("Ali", User_Role.MANAGER);
            actual.Add(user1);
            actual.Add(user2);
            expected.Add(user1);
            expected.Add(user2);
            Assert.AreEqual(expected.Count, actual.Count);
            Assert.AreEqual(expected[0].Username, actual[0].Username);
        }

        [TestMethod()]
        public void MyTest3()
        {
            Hand h = new Hand("8C 10S 13X 9H 4S");
            Assert.AreEqual(h.Cards[2].Suit, Suit.CLUBS); //defalt suit
        }

        [TestMethod]
        public void TestMethod1()
        {

            int Expected = 7;
            Card c = new Card(Expected, Suit.SPADES);

            Assert.AreEqual(Expected, c.Number);
        }


        [TestMethod]
        public void TestHandSorting()
        {
            Card card = new Card(5, Suit.DIAMONDS);
            Card card2 = new Card(7, Suit.HEARTS);
            Card card3 = new Card(2, Suit.HEARTS);
            Card card4 = new Card(14, Suit.HEARTS);
            Card card5 = new Card(10, Suit.SPADES);
            Card[] cards = { card, card2, card3, card4, card5 };

            Hand hand = new Hand();
            hand.Cards = cards;
            hand.Sort();
            int num = 0;
            for (int i = 0; i < cards.Length; i++)
            {
                Assert.IsTrue(num <= cards[i].Number, $"Expected {cards[i].Number} to be greater than {num}, but it was not. lingar");

                num = cards[i].Number;
            }

        }

        [TestMethod]
        public void TestStringToHand()
        {
            Card[] cards = new Card[5];
            //8C TS KC 9H 4S
            cards[0] = new Card(8, Suit.CLUBS);
            cards[1] = new Card(10, Suit.SPADES);
            cards[2] = new Card(13, Suit.CLUBS);
            cards[3] = new Card(9, Suit.HEARTS);
            cards[4] = new Card(4, Suit.SPADES);


            //...
            Hand h = new Hand("8C 10S 13C 9H 4S");

            for (int i = 0; i < cards.Length; i++)
            {
                Assert.AreEqual(cards[i].Number, h.Cards[i].Number);

                Assert.AreEqual(cards[i].Suit, h.Cards[i].Suit);

            }


        }
    }
}