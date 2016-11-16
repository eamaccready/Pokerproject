using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//dgarber@microsoft.com for help!
namespace Poker
{
    // make cards enums.
    enum CardSuit { Clubs, Diamonds, Hearts, Spades };
    enum CardRank
    {
        two,
        three,
        four,
        five,
        six,
        seven,
        eight,
        nine,
        ten,
        jack,
        queen,
        king,
        ace
    }

    // Create Card class.
    class Card : IComparable
    {
        public CardSuit suit;
        public CardRank rank;

        public Card(CardSuit suit, CardRank rank)
        {
            this.suit = suit;
            this.rank = rank;
        }

        public int CompareTo(object obj)
        {
            Card c = obj as Card;
            return rank - c.rank;
        }
    }

    // Create Hand Class.
    class Hand // make array and dictionary of 5 Cards.
    {
        private Dictionary<CardRank, int> HandCounts = new Dictionary<CardRank, int>();
        private Card[] elements;
        public Hand(Card[] cards)// need to get from a Deal().
        {
            elements = cards;
            //Sorted array of cards from deck/deal.
            Array.Sort(elements);
            // elements = cards.OrderBy(x => x.rank).ToArray();//change var name or overwrite?
            for (int i = 0; i < elements.Length; i++)
            {
                var rank = elements[i].rank;
                if (!HandCounts.ContainsKey(rank))
                {
                    HandCounts[rank] = 1;
                }
                else
                {
                    HandCounts[rank] += 1;
                }
            }
        }

        public Card[] cards
        {
            get
            {
                return elements;
            }
        }
        public Dictionary<CardRank, int> handCounts
        {
            get
            {
                return HandCounts;
            }
        }

        //Add dict constructor with same deal so you can get counts of the same rank.
        // Key is rank, value is counts.
        // Correct? Constructor or Method?
        // Loop through hand and collect counts of CardRank.
    }

    //Create Deck Class.
    class Deck
    {
        private List<Card> deck = new List<Card>();//

        // Loop through enums to get all unique values and append to deck.
        public Deck()
        {
            foreach (CardSuit suit in Enum.GetValues(typeof(CardSuit)))
            {
                foreach (CardRank rank in Enum.GetValues(typeof(CardRank)))
                {
                    deck.Add(new Card(suit, rank));
                }
            }

        }

        // moved GetHand() here and return new Hand. // method to get a new hand.
        public Hand Deal()
        {
            Card[] cards = new Card[5];
            var random = new Random();
            for (int i = 0; i < 5; i++)
            {
                int cardIndex = (int)(random.NextDouble() * deck.Count);
                cards[0] = deck.ElementAt(cardIndex);
                deck.RemoveAt(cardIndex);
            }
            // Pass array into constructor.
            Hand NewHand = new Hand(cards);
            return NewHand;
        }

    }



    class Program
    {
        static void Main(string[] args)
        {

            //Deal an new hand.
            Deck deck = new Deck();
            Hand NameHand = deck.Deal();

            //print results to end user.
            /* //Prints results of hand to end user.
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
                */
            Console.ReadLine();// I think this is correct since there's fake brackets here...
        }


        // function to evaluate if hand is straight flush.
        static bool isStraightFlush(Hand hand)
        {
            return isFlush(hand) && isStraight(hand);
        }

        static bool isFlush(Hand hand)
        {
            for (int i = 1; i < hand.cards.Length; i++)
            {
                if (hand.cards[i].suit != hand.cards[0].suit)
                    return false;
            }
            return true;
        }

        static bool isStraight(Hand hand)//Assuming sorted.
        {
            for (int i = 1; i < hand.cards.Length; i++)
            {
                if (hand.cards[i].rank != hand.cards[i - 1].rank + 1)
                    return false;
            }
            return true;
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
                                           