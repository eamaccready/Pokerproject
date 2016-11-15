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
    class Card //: IComparable
    {
        public CardSuit suit;
        public CardRank rank;

        public Card(CardSuit suit, CardRank rank)
        {
            this.suit = suit;
            this.rank = rank;
        }
    }

    // Create Hand Class.
    class Hand // make array and dictionary of 5 Cards.
    {
        private Card[] elements;
        public Hand(Card[] cards)// need to get from a Deal().
        {
            //Sorted array of cards from deck/deal.
            elements = cards.OrderBy(x => x.rank).ToArray();//change var name or overwrite?
        }

        //Add dict constructor with same deal so you can get counts of the same rank.
        // Key is rank, value is counts.
        private Dictionary<CardRank, int> HandCounts = new Dictionary<CardRank, int>();// Correct? Constructor or Method?
        // Loop through hand and collect counts of CardRank.
    }

    //Create Deck Class.
    class Deck // move GetHand() here and return new Hand.
    {
        private List<Card> deck = new List<Card>();

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

        public static Hand GetHand()// do I not use the type Hand here to call method?
        {
            //Shuffle deck(Randomize)pull, insert into array. no replacement.
            
            //Deal a hand of 5 Cards.

            return NewHand;
        }
         
        // method to get a new hand.
    }



    class Program
    {
        static void Main(string[] args)
        {

            //Deal an new hand.
            Hand NameHand = GetHand(args);//Change to a new hand = GetHand, since a hand is array of cards.

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

            Console.ReadLine();// I think this is correct since there's fake brackets here...
        }*/

/*
// function to get a new hand.
static Hand GetHand(string[] args)// This is affected with a hand class.
{
 Hand hand = new Hand();
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
return Hand;
}

//Make function to deal a hand. 
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
                                           