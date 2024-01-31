using System.Collections.Generic;
using System;

namespace Project_1
{
    public class Card {
        private string suitName = "";
        
        public string Suit { 
            get { return suitName; } 
            set { suitName = value; } 
        }
         
        private int rankNum;
        public int Rank { 
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

        static void Main(string[] args)
        {
            Console.WriteLine("Deck of Cards");
            Console.WriteLine("-------------");
            
            DisplayMenu(choice);
        }

        public static void DisplayMenu(int choice) {
            if(choice != 0) {
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
                            // ShuffleDeck();
                            break;
                        case 3:
                            //DealDeck();
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
            } else { 
                return;
            }
        }

        public static void createCard(Card card, string suit, int rank) {
            card.Suit = suit;
            card.Rank = rank;
        }

        public static void CreateNewDeck () {
            string[] suitNames = { "Hearts", "Diamonds", "Clubs", "Spades" };

            for(int i = 0; i < SUITCOUNT; i++) {
                for(int j = 0; j < CARDCOUNT; j++) {
                    Card newCard = new Card();
                    createCard(newCard, suitNames[i], j+1);

                    deck.AddLast(newCard);
                }
            }

            DisplayMenu(choice);
        }

        public static void DisplayDeck () {
            if(deck.Count == 0) {
                Console.WriteLine("Deck is Empty!");
                DisplayMenu(choice);
            } else {
                int count = 0;

                foreach (var item in deck)
                {
                    count++;
                    switch(item.Rank) {
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
        }
    }
}

