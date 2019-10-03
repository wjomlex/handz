using System.Collections;
using System.Collections.Generic;

public class Trick
{
    public List<Card> cards;
    public int leader;
    public int winner;

    public Trick(int leader) {
        this.leader = leader;
        cards = new List<Card>();
    }
}
