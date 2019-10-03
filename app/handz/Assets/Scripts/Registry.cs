using System;
using System.Collections;
using System.Collections.Generic;

public class Registry
{
    public const int NONE = 0;
    public const int NS = 1;
    public const int EW = 2;
    public const int ALL = 3;

    public static Random rnd = new Random();

    public static int level = 0;
    public static int boardNumber = 0;
    public static int contractStrain = Card.NOTRUMP;
    public static int contractLevel = 1;
    public static int currentPlayer = Hand.SOUTH;

    public static List<Card>[] hands = new List<Card>[4];
    public static int declarer = Hand.SOUTH;
    public static List<Trick> tricks;
    public static Trick currentTrick;

    public static void Shuffle() {
        Card[] deck = new Card[52];
        for (int suit = 0; suit < 4; suit++)
            for (int rank = 0; rank < 13; rank++)
                deck[13 * suit + rank] = new Card(suit, rank);

        // Fisher-Yates shuffle
        for (int i=0;i < 51;i++) {
            int j = rnd.Next(i, 52);
            Card tmp = deck[i];
            deck[i] = deck[j];
            deck[j] = tmp;
        }

        hands[Hand.NORTH] = new List<Card>();
        hands[Hand.SOUTH] = new List<Card>();
        hands[Hand.WEST] = new List<Card>();
        hands[Hand.EAST] = new List<Card>();

        for (int i = 0; i < 13; i++) hands[Hand.NORTH].Add(deck[i]);
        for (int i = 13; i < 26; i++) hands[Hand.SOUTH].Add(deck[i]);
        for (int i = 26; i < 39; i++) hands[Hand.WEST].Add(deck[i]);
        for (int i = 39; i < 52; i++) hands[Hand.EAST].Add(deck[i]);

        hands[Hand.NORTH].Sort();
        hands[Hand.SOUTH].Sort();
        hands[Hand.WEST].Sort();
        hands[Hand.EAST].Sort();

        tricks = new List<Trick>();
        boardNumber++;
        currentPlayer = Hand.WEST;
        declarer = Hand.SOUTH;
        currentTrick = new Trick(currentPlayer);
    }

    public static int GetDealer() {
        if (boardNumber % 4 == 1) return Hand.NORTH;
        if (boardNumber % 4 == 2) return Hand.EAST;
        if (boardNumber % 4 == 3) return Hand.SOUTH;
        return Hand.WEST;
    }

    public static int GetVulnerability() {
        int board = boardNumber % 16 + 1;
        if (board == 1 || board == 8 || board == 11 || board == 14) return NONE;
        if (board == 2 || board == 5 || board == 12 || board == 15) return NS;
        if (board == 3 || board == 6 || board == 9 || board == 16) return EW;
        return ALL;
    }
}
