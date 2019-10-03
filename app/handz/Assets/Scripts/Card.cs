using System;
using System.Collections;
using System.Collections.Generic;

public class Card : IComparable<Card>
{
    public static int NOTRUMP = -1;
    public static int SPADES = 0;
    public static int HEARTS = 1;
    public static int DIAMONDS = 2;
    public static int CLUBS = 3;

    public int suit;
    public int rank;

    public Card(int suit, int rank) {
        this.suit = suit;
        this.rank = rank;
    }

    public int CompareTo(Card that) {
        if (this.suit < that.suit) return -1;
        if (this.suit > that.suit) return 1;
        return this.rank - that.rank;
    }
}
