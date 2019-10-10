using System;
using System.Collections;
using System.Collections.Generic;

public class Registry
{
    public static Random rnd = new Random();

    public static int level = 0;
    public static int boardNumber = 0;
    public static Strain contractStrain = Strain.NOTRUMP;
    public static int contractLevel = 1;
    public static Direction currentPlayer = Direction.WEST;

    public static Dictionary<Direction, List<Card>> hands = new Dictionary<Direction, List<Card>>();
    public static Direction declarer = Direction.SOUTH;
    public static List<Trick> tricks;
    public static Trick currentTrick;

    public static void Shuffle() {
        Card[] deck = new Card[52];
        for (int suit = 0; suit < 4; suit++)
            for (int rank = 0; rank < 13; rank++)
                deck[13 * suit + rank] = new Card((Strain)suit, rank);

        // Fisher-Yates shuffle
        for (int i=0;i < 51;i++) {
            int j = rnd.Next(i, 52);
            Card tmp = deck[i];
            deck[i] = deck[j];
            deck[j] = tmp;
        }

        hands[Direction.NORTH] = new List<Card>();
        hands[Direction.SOUTH] = new List<Card>();
        hands[Direction.WEST] = new List<Card>();
        hands[Direction.EAST] = new List<Card>();

        for (int i = 0; i < 13; i++) hands[Direction.NORTH].Add(deck[i]);
        for (int i = 13; i < 26; i++) hands[Direction.SOUTH].Add(deck[i]);
        for (int i = 26; i < 39; i++) hands[Direction.WEST].Add(deck[i]);
        for (int i = 39; i < 52; i++) hands[Direction.EAST].Add(deck[i]);

        hands[Direction.NORTH].Sort();
        hands[Direction.SOUTH].Sort();
        hands[Direction.WEST].Sort();
        hands[Direction.EAST].Sort();

        tricks = new List<Trick>();
        boardNumber++;
        currentPlayer = Direction.WEST;
        declarer = Direction.SOUTH;
        currentTrick = new Trick(currentPlayer);
    }

    public static Direction GetDealer() {
        if (boardNumber % 4 == 1) return Direction.NORTH;
        if (boardNumber % 4 == 2) return Direction.EAST;
        if (boardNumber % 4 == 3) return Direction.SOUTH;
        return Direction.WEST;
    }

    public static Vulnerability GetVulnerability() {
        int board = boardNumber % 16 + 1;
        if (board == 1 || board == 8 || board == 11 || board == 14) return Vulnerability.NONE;
        if (board == 2 || board == 5 || board == 12 || board == 15) return Vulnerability.NS;
        if (board == 3 || board == 6 || board == 9 || board == 16) return Vulnerability.EW;
        return Vulnerability.ALL;
    }
}
