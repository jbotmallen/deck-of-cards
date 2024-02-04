﻿using System.Collections.Generic;
using System;

namespace Project_1
{
    public class Card
    {
        private string suitName = "";

        public string Suit
        {
            get { return suitName; }
            set { suitName = value; }
        }

        private int rankNum;
        public int Rank
        {
            get { return rankNum; }
            set { rankNum = value; }
        }
    }

    class Program
    {
        protected static int SUITCOUNT = 4;
        protected static int CARDCOUNT = 13;

        public static int choice = -1;
        public static LinkedList<Card> deck = new LinkedList<Card>();
        public static LinkedList<Card> shuffledDeck = new LinkedList<Card>();

        static void Main(string[] args)
        {
            Console.WriteLine("Deck of Cards");
            Console.WriteLine("-------------");

            DisplayMenu(choice);
        }

        public static void DisplayMenu(int choice)
        {
            if (choice != 0)
            {
                Console.WriteLine("1. Create a new deck of cards");
                Console.WriteLine("2. Shuffle the current deck of cards");
                Console.WriteLine("3. Deal the current deck of cards");
                Console.WriteLine("4. Display the current deck of cards");
                Console.WriteLine("0. Exit");

                Console.WriteLine("Enter your choice: ");
                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            CreateNewDeck();
                            break;
                        case 2:
                            ShuffleDeck();
                            break;
                        case 3:
                            DealDeck();
                            break;
                        case 4:
                            DisplayDeck();
                            break;
                        case 0:
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Something went wrong! Please try again.\n\n" + e);
                }
            }
            else
            {
                return;
            }
        }

        public static void createCard(Card card, string suit, int rank)
        {
            card.Suit = suit;
            card.Rank = rank;
        }

        public static void CreateNewDeck()
        {
            string[] suitNames = { "Hearts", "Diamonds", "Clubs", "Spades" };
            if (deck.Count == 0)
            {
                for (int i = 0; i < SUITCOUNT; i++)
                {
                    for (int j = 0; j < CARDCOUNT; j++)
                    {
                        Card newCard = new Card();
                        createCard(newCard, suitNames[i], j + 1);

                        deck.AddLast(newCard);
                    }
                }
            }
            else
            {
                Console.WriteLine("There are still cards on deck!");

            }

            Console.Write("Press any key to return to menu...");
            Console.ReadKey(true);
            Console.Clear();
            DisplayMenu(choice);
        }

        public static void DisplayDeck()
        {
            if (deck.Count == 0)
            {
                Console.WriteLine("Deck is Empty!");
            }
            else
            {
                int count = 0;

                foreach (var item in deck)
                {
                    count++;
                    switch (item.Rank)
                    {
                        case 1:
                            Console.WriteLine("Suit: " + item.Suit + " " + "Rank: " + "Ace");
                            continue;
                        case 11:
                            Console.WriteLine("Suit: " + item.Suit + " " + "Rank: " + "Jack");
                            continue;
                        case 12:
                            Console.WriteLine("Suit: " + item.Suit + " " + "Rank: " + "Queen SLAAAAAYYY");
                            continue;
                        case 13:
                            Console.WriteLine("Suit: " + item.Suit + " " + "Rank: " + "King");
                            continue;
                        default:
                            Console.WriteLine("Suit: " + item.Suit + " " + "Rank: " + item.Rank);
                            continue;
                    }
                }
            }
            Console.WriteLine("Number of cards: " + deck.Count);
            Console.Write("Press any key to return to menu...");
            Console.ReadKey(true);
            Console.Clear();
            DisplayMenu(choice);
        }

        public static void ShuffleDeck()
        {
            Random random = new Random();
            if (deck.Count == 0)
            {
                Console.WriteLine("No cards on deck yet!");
            }
            while (deck.Count > 0)
            {
                int index = random.Next(deck.Count);
                Card card = deck.ElementAt(index);
                shuffledDeck.AddFirst(card);
                deck.Remove(card);
            }


            foreach (Card card in shuffledDeck)
            {
                deck.AddLast(card);
            }

            shuffledDeck.Clear();

            Console.Write("Press any key to return to menu...");
            Console.ReadKey(true);
            Console.Clear();
            DisplayMenu(choice);
        }

        public static void DealDeck()
        {
            int dealCount;
            if (deck.Count > 0)
            {
                Console.Write("How many cards would you like to deal? ");
                dealCount = Convert.ToInt32(Console.ReadLine());
                if (dealCount <= deck.Count)
                {
                    while (dealCount > 0 && dealCount <= deck.Count)
                    {
                        var item = deck.First.Value;
                        Console.Write("Suit: " + item.Suit + " ");
                        switch (item.Rank)
                        {

                            case 1:
                                Console.WriteLine("Suit: " + item.Suit + " " + "Rank: " + "Ace");
                                break;
                            case 11:
                                Console.WriteLine("Suit: " + item.Suit + " " + "Rank: " + "Jack");
                                break;
                            case 12:
                                Console.WriteLine("Suit: " + item.Suit + " " + "Rank: " + "Queen SLAAAAAYYY");
                                break;
                            case 13:
                                Console.WriteLine("Suit: " + item.Suit + " " + "Rank: " + "King");
                                break;
                            default:
                                Console.WriteLine("Suit: " + item.Suit + " " + "Rank: " + item.Rank);
                                break;
                        }
                        deck.RemoveFirst();
                        dealCount--;
                    }
                }
                else
                {
                    Console.WriteLine("Cannot deal if deck has less cards than the asked number! ");
                }
            }
            else
            {

                Console.WriteLine("The deck is empty!");
            }
            Console.Write("Press any key to return to menu...");
            Console.ReadKey(true);
            Console.Clear();
            DisplayMenu(choice);
        }

    }
}
