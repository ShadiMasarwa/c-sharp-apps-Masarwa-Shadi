using System;
using System.Collections.Generic;
using c_sharp_apps_Masarwa_Shadi.PokerGame.users;
using c_sharp_apps_Masarwa_Shadi.SportApp;
using c_sharp_apps_Masarwa_Shadi.PokerGame.poker_hands;


namespace c_sharp_apps_Masarwa_Shadi.PokerGame.game_area
{
    public class GameSystem
    {
        public static void AddTable(List<User> listOfUsers)
        {
            bool finished = false;
            while (!finished)
            {
                Screen.Clean();
                Console.WriteLine("Usres Menu");
                Console.WriteLine("===========");
                for (int i = 0; i < listOfUsers.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {listOfUsers[i].Username}, Role: {listOfUsers[i].Role}");
                }

                Console.WriteLine();
                Console.WriteLine("0. Exit");
                Console.WriteLine("=====================");
                Console.Write("Enter your user ID: ");
                char ch = Console.ReadKey().KeyChar;
                Console.WriteLine();
                int choice = ch - 48;
                if (choice == 0)
                {
                    finished = true;
                    break;
                }
                if (listOfUsers.Count < choice || choice < 0)
                {
                    Console.WriteLine("Invalid user ID!");
                    Console.ReadKey();
                    continue;
                }
                if (listOfUsers[choice - 1].Role == User_Role.PLAYER)
                {
                    Console.WriteLine("You are not allowed to open a table!");
                    Console.ReadKey();
                    continue;
                }
                //List<User> tableUsers = new List<User>();
                List<User> tempPlayers = new List<User>();
                List<User> players = new List<User>();
                for (int i = 0; i < listOfUsers.Count; i++)
                {
                    if (listOfUsers[i].Role == User_Role.PLAYER)
                    {
                        tempPlayers.Add(listOfUsers[i]);
                    }
                }
                while (true)
                {
                    Screen.Clean();
                    Console.WriteLine($"Table Opened - {players.Count} players");
                    Console.WriteLine("============");
                    Console.WriteLine("Add players to table");
                   
                    for (int i = 0; i < tempPlayers.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {tempPlayers[i].Username}, Role: {tempPlayers[i].Role}");
                    }
                    Console.WriteLine();
                    Console.WriteLine("0. Exit");
                    Console.WriteLine("=====================");
                    if (tempPlayers.Count == 0)
                    {
                        Console.WriteLine("No players available to add!");
                        Console.ReadKey();
                        break;
                    }
                    Console.Write("Enter num of player: ");
                    ch = Console.ReadKey().KeyChar;
                    choice = ch - 48;
                    if (choice == 0)
                        break;
                    else
                        players.Add(tempPlayers[choice - 1]);

                }
                if (players.Count > 0)
                {
                    Screen.Clean();
                    Console.WriteLine("Table opened with players:");
                    Console.WriteLine("=========================");
                    for (int i = 0; i < players.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {players[i].Username}, Role: {players[i].Role}");
                    }
                    Console.WriteLine("=========================");

                    Console.WriteLine();
                    for(int i=0; i<players.Count; i++)
                    {
                        Console.WriteLine($"Enter Hand For Player {i+1}");
                        Console.WriteLine("Hand like (8D, 1S, 9C, 14H, 8C)");
                        Console.Write("Enter hand here:");
                        string hand = Console.ReadLine();
                        string[] cards = hand.Split(new string[] { ", " }, StringSplitOptions.None);
                        if (cards.Length != 5)
                        {
                            Console.WriteLine("Invalid Hand. Only 5 Card Allowed");
                            Console.ReadKey();
                            i--;
                            continue;
                        }
                        for (int j=0; j < cards.Length; j++)
                        {
                            char suit = cards[j][cards[j].Length - 1];
                            int num = int.Parse(cards[j].Substring(0, cards[i].Length - 1));
                            if (suit != 'H' && suit != 'C' && suit != 'S' && suit != 'D' || (num>14 || num < 1))
                            {
                                Console.WriteLine("Invalid Cards");
                                Console.ReadKey();
                                j--;
                                continue;
                            }
                        }
                        Card[] currCards = new Card[5];
                        for (int j = 0; j < cards.Length; j++)
                        {
                            Card currCard;
                            Suit currSuit;
                            char suit = cards[j][cards[j].Length - 1];
                            int num = int.Parse(cards[j].Substring(0, cards[i].Length - 1));
                            switch (suit)
                            {
                                case 'H':
                                    currSuit = Suit.HEARTS;
                                    break;
                                case 'C':
                                    currSuit = Suit.CLUBS;
                                    break;
                                case 'S':
                                    currSuit = Suit.SPADES;
                                    break;
                                case 'D':
                                    currSuit = Suit.DIAMONDS;
                                    break;
                                default:
                                    currSuit = Suit.HEARTS;
                                    break;
                            }
                            currCard = new Card(num, currSuit);
                            currCards[j] = currCard;
                        }
                        players[i].Hand.Cards = currCards;
                        Console.WriteLine();
                        Console.WriteLine("--------------");
                        Console.WriteLine();

                    }
                    Console.WriteLine("All OK!!!!");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("No players added to table!");
                    Console.ReadKey();
                }
            }
        }
    }
}
