using System.Collections;
using System.Collections.Generic;

public class Trick
{
    public List<Card> cards;
    public Direction leader;
    public Direction winner;

    public Trick(Direction leader) {
        this.leader = leader;
        cards = new List<Card>();
    }

    public void Add(Card card) {
        cards.Add(card);

        // Set the winner if the trick is complete
        if (cards.Count == 4) {
            bool trumpPlayed = cards[0].suit == Registry.contractStrain;
            int rank = cards[0].rank;
            Direction player = leader;
            winner = leader;

            for (int i=1;i < 4;i++) {
                player = TableController.NextPlayer(player);
                if (cards[i].suit == Registry.contractStrain) {
                    if (!trumpPlayed || cards[i].rank < rank) {
                        trumpPlayed = true;
                        rank = cards[i].rank;
                        winner = player;
                    }
                } else if (cards[i].suit == cards[0].suit && !trumpPlayed && cards[i].rank < rank) {
                    rank = cards[i].rank;
                    winner = player;
                }
            }
        }
    }
}
