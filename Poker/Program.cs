using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//dgarber@microsoft.com for help!
namespace Poker
{
    class Card : IComparable
    {
        public char suit; //CHDS 
        public int rank;  // 2=2, K=13, A = 14

        public Card()// why is method overloaded? What should this do?
        {

        }

        public Card(string str)//method to process cardtype input.
        {
            str = str.ToUpper();// converts all input to upper case.
            foreach (char c in str)
            {
                switch (c) // is this the best way to handle?
                {
                    case 'C':
                    case 'D':
                    case 'H':
                    case 'S':
                        suit = c;
                        break;
                    case 'A':
                        rank = 14;
                        break;
                    case 'K':
                        rank = 13;
                        break;
                    case 'Q':
                        rank = 12;
                        break;
                    case 'J':
                        rank = 11;
                        break;
                    case 'T':// should I make a case for T and 10? or is string only taking 2 spots as input?
                        rank = 10;
                        break;
                    case '9':
                    case '8':
                    case '7':
                    case '6':
                    case '5':
                    case '4':
                    case '3':
                    case '2':
                        rank = c - '0'; //idiom to get int value, I think...
                        break;
                }
            }

            if (rank == 0)
                Console.WriteLine("Please enter a rank for " + str);
        }

        bool isValid()
        {
            return suit != '\0' && rank >= 2 && rank <= 14;
        }

        public int CompareTo(object obj)
        {
            Card c = obj as Card;
            return rank - c.rank;
        }
    }

    class Hand // make array and dictionary of Cards
    {

    }

    class Program
    {
        static void Main(string[] args)
        {
            Card[] hand = GetHand(args);//Change to a new hand = GetHand, since a hand is array of cards.

            //Card[] hand = new Card[5];
            // hand[0] = new Card();
            //hand[0].suit = 'C';
            //hand[0].rank = 8;
            //....
            Array.Sort(hand);

            //Prints hand to end user in console.
            if (isStraightFlush(hand))
                Console.WriteLine("Straight flush!");
            else if (isFourOfKind(hand))
                Console.WriteLine("Four of a kind!");
            else if (isFullHouse(hand))
                Console.WriteLine("Full house!");
            else if (isFlush(hand))
                Console.WriteLine("Flush!");
            else if (isStraight(hand))
                Console.WriteLine("Straight!");
            else if (isThreeOfKind(hand))
                Console.WriteLine("Three of a kind!");
            else if (isTwoPair(hand))
                Console.WriteLine("Two pair!"); // also print pairs?
            else if (isPair(hand))
                Console.WriteLine("A pair!"); //also print value of pair?
            else
                Console.WriteLine("Your highest card is: " + hand[5]); // print last value of array since is sorted.
        }

        static Card[] GetHand(string[] args)
        {
            Card[] hand = new Card[5];
            int index = 0;
            foreach (string a in args)
            {
                if (index >= 5)
                    break;
                Card c = new Card(a);
                hand[index++] = c;
            }

            while (index < 5)
            {
                hand[index++] = Deal();
            }
            return hand;
        }


        // create a deck and deal a random card.
        static Card[] deck = null;
        static int dealIndex = 0;

        static Card Deal()
        {
            if (deck == null | dealIndex >= 52)
            {
                deck = new Card[52];
                int index = 0;
                // todo : one of each card == loop!
                //shuffle (randomize)
            }
            return deck[dealIndex++];
        } //end class program.

        // function to evaluate if hand is straight flush.
        static bool isStraightFlush(Card[] hand)
        {
            return isStraightFlush(hand) && isStraightFlush(hand);
        }

        static bool isFlush(Card[] hand)
        {
            for (int i = 1; i < hand.Length; i++)
            {
                if (hand[i].suit != hand[0].suit)
                    return false;
            }
            return true;
        }

        static bool isStraight(Card[] hand)//Assuming sorted.
        {
            for (int i = 1; i < hand.Length; i++)
            {
                if (hand[i].rank != hand[i - 1].rank + 1)
                    return false;
            }
            return true;
        }

        static void cardCounts(Card[] hand)// Maybe void? I want counts of each rank.
        {
            // make dictionary of all ranks so you can get counts.
            Dictionary<string, int>;
        }

        // 
        static bool isFullhouse(Card[] hand)
        {
            //if cardCounts counts 3==true && 2==true. return true.
            return true;
        }

        static bool isThreeOfKind(Card[] hand)
        {
            //If cardMatches counts ==3 is true && 2 is false.
            return true;
        }

        static bool isTwoPair(Card[] hand)
        {
            //if cardMatches counts == 2 * 2 . return true
            return true;
        }
        static bool isPair(Card[] hand)
        {
            //if cardMatches counts == 2 * 1. return true 
            return true;
        }
    }
}

// if counts == 3 && counts ==2; return is Full house
// else if counts == 3 and counts!= 2 return is 3 of kind
// else if counts == 2 and ==2 again return is 2 pair
//else if counts == 2 and not 2 again return is pair
// else return high card from sorted array.