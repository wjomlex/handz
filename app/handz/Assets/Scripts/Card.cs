using System;
using System.Collections;
using System.Collections.Generic;

public class Card : IComparable<Card>
{
    public Strain suit;
    public int rank;
    public bool played;

    public Card(Strain suit, int rank) {
        this.suit = suit;
        this.rank = rank;
        played = false;
    }

    public int CompareTo(Card that) {
        if (this.suit < that.suit) return -1;
        if (this.suit > that.suit) return 1;
        return this.rank - that.rank;
    }

    public override String ToString() {
        return suit + " " + (14 - rank);
    }
}
