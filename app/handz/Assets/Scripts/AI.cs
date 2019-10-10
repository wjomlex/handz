using System.Collections.Generic;
using System;

public class AI
{
    // Return the index of the card to play from myHand
    // TODO: We'll need the auction as well in the future
    public static int SelectCard(List<Trick> tricks, Trick currentTrick, DummyPosition dummyPosition, List<Card> myHand, List<Card> visibleHand, Strain contractStrain, int contractLevel) {
        // State of the art AI: play a random legal card!
        Random rnd = new Random();

        // Look for cards in suit led. Empty if we're first to lead.
        List<int> cardsInSuitLed = new List<int>(); 
        if (currentTrick.cards.Count > 0) {
            for (int i=0;i < myHand.Count;i++) {
                Card card = myHand[i];
                if (card.suit == currentTrick.cards[0].suit) {
                    cardsInSuitLed.Add(i);
                }
            }
        }

        // If we have cards in the suit led, we need to play one of them.
        if (cardsInSuitLed.Count > 0) {
            return cardsInSuitLed[rnd.Next(cardsInSuitLed.Count)];
        }

        return rnd.Next(myHand.Count);
    }
}
