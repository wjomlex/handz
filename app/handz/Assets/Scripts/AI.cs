using System.Collections;
using System.Collections.Generic;

public class AI
{
    // Dummy positions
    const int ME = 0;
    const int PARTNER = 1;
    const int LEFT = 2;
    const int RIGHT = 3;

    // TODO: We'll need the auction as well in the future
    public static int SelectCard(List<Trick> tricks, Trick currentTrick, int dummyPosition, List<Card> myHand, List<Card> visibleHand, int contractStrain, int contractLevel) {
        // State of the art AI: play a random legal card!
        return 0;
    }
}
