using System.Collections.Generic;
using System;
using UnityEngine;

public class AI
{
    // Return the index of the card to play from myHand
    // TODO: We'll need the auction as well in the future
    public static int SelectCard(List<Trick> tricks, Trick currentTrick, DummyPosition dummyPosition, List<Card> myHand, List<Card> visibleHand, Strain contractStrain, int contractLevel) {
        // State of the art AI: play a random legal card!
        System.Random rnd = new System.Random();

        // Look for unplayed cards in suit led. Empty if we're first to lead.
        List<int> cardsInSuitLed = new List<int>(); 
        if (currentTrick.cards.Count > 0) {
            for (int i=0;i < myHand.Count;i++) {
                Card card = myHand[i];
                if (card.suit == currentTrick.cards[0].suit && !card.played) {
                    cardsInSuitLed.Add(i);
                }
            }
        }

        // If we have cards in the suit led, we need to play one of them.
        if (cardsInSuitLed.Count > 0) {
            return cardsInSuitLed[rnd.Next(cardsInSuitLed.Count)];
        }

        // Otherwise play first legal card
        for (int i=0;i < myHand.Count;i++) {
            if (!myHand[i].played) return i;
        }

        Debug.Log("No legal cards found!");
        return 0;
    }
}
