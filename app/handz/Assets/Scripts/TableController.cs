using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableController : MonoBehaviour
{
    const float timeBetweenPlays = 1.0f;
    float timeSinceLastPlay;

    void Start()
    {
        timeSinceLastPlay = 0;
    }

    void Update()
    {
        timeSinceLastPlay += Time.deltaTime;
        if (CurrentPlayerHandledByAI() && timeSinceLastPlay >= timeBetweenPlays) {
            HandleAIPlay();
        }
    }

    void HandleAIPlay() {
        List<Card> currentHand = Registry.hands[Registry.currentPlayer];
        int cardIdx = AI.SelectCard(
            Registry.tricks,
            Registry.currentTrick,
            GetDummyPosition(Registry.currentPlayer, Registry.declarer),
            currentHand,
            Registry.hands[GetVisiblePlayer(Registry.currentPlayer, Registry.declarer)],
            Registry.contractStrain,
            Registry.contractLevel
        );

        Card card = currentHand[cardIdx];
        Debug.Log(Registry.currentPlayer + " PLAYS " + card.ToString());

        currentHand.RemoveAt(cardIdx);
        Registry.currentTrick.Add(card);
        if (Registry.currentTrick.cards.Count == 4) {
            Registry.tricks.Add(Registry.currentTrick);
            Registry.currentTrick = new Trick(Registry.currentTrick.winner);
            Registry.currentPlayer = Registry.currentTrick.leader;
        } else {
            Registry.currentPlayer = NextPlayer(Registry.currentPlayer);
        }

        timeSinceLastPlay = 0;
    }

    public bool CurrentPlayerHandledByAI() {
        return Registry.currentPlayer == Direction.WEST
          || Registry.currentPlayer == Direction.EAST
          || Registry.currentPlayer == Direction.NORTH && (Registry.declarer == Direction.EAST || Registry.declarer == Direction.WEST);
    }

    public static Direction NextPlayer(Direction currentPlayer) {
        switch (currentPlayer) {
            case Direction.WEST: return Direction.NORTH;
            case Direction.EAST: return Direction.SOUTH;
            case Direction.NORTH: return Direction.EAST;
            case Direction.SOUTH: return Direction.WEST;
        }

        Debug.Log("Impossible to reach");
        return Direction.SOUTH;
    }

    DummyPosition GetDummyPosition(Direction currentPlayer, Direction declarer) {
        DummyPosition dummy = DummyPosition.ME;

        switch (currentPlayer) {
            case Direction.WEST:
                switch (declarer) {
                    case Direction.WEST: dummy = DummyPosition.PARTNER; break;
                    case Direction.EAST: dummy = DummyPosition.ME; break;
                    case Direction.NORTH: dummy = DummyPosition.RIGHT; break;
                    case Direction.SOUTH: dummy = DummyPosition.LEFT; break;
                }
                break;
            case Direction.NORTH:
                switch (declarer) {
                    case Direction.WEST: dummy = DummyPosition.LEFT; break;
                    case Direction.EAST: dummy = DummyPosition.RIGHT; break;
                    case Direction.NORTH: dummy = DummyPosition.PARTNER; break;
                    case Direction.SOUTH: dummy = DummyPosition.ME; break;
                }
                break;
            case Direction.EAST:
                switch (declarer) {
                    case Direction.WEST: dummy = DummyPosition.ME; break;
                    case Direction.EAST: dummy = DummyPosition.PARTNER; break;
                    case Direction.NORTH: dummy = DummyPosition.LEFT; break;
                    case Direction.SOUTH: dummy = DummyPosition.RIGHT; break;
                }
                break;
            case Direction.SOUTH:
                switch (declarer) {
                    case Direction.WEST: dummy = DummyPosition.RIGHT; break;
                    case Direction.EAST: dummy = DummyPosition.LEFT; break;
                    case Direction.NORTH: dummy = DummyPosition.ME; break;
                    case Direction.SOUTH: dummy = DummyPosition.PARTNER; break;
                }
                break;
        }

        return dummy;
    }

    // Returns the direction of the other hand that the current player can see.
    // That's the dummy, unless you *are* the dummy in which case it's declarer's hand.
    Direction GetVisiblePlayer(Direction currentPlayer, Direction declarer) {

        Direction dummy = Direction.SOUTH;
        switch (declarer) {
            case Direction.WEST: dummy = Direction.EAST; break;
            case Direction.EAST: dummy = Direction.WEST; break;
            case Direction.NORTH: dummy = Direction.SOUTH; break;
            case Direction.SOUTH: dummy = Direction.NORTH; break;
        }

        return currentPlayer == dummy ? declarer : dummy;
    }
}
