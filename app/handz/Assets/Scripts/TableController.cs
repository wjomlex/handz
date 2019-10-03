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
        if (Registry.currentPlayer == Hand.WEST || Registry.currentPlayer == Hand.EAST && timeSinceLastPlay >= timeBetweenPlays) {
            HandleAIPlay();
        }
    }

    void HandleAIPlay() {
        AI.SelectCard(
            Registry.tricks,
            Registry.currentTrick,
            GetDummyPosition(Registry.currentPlayer, Registry.declarer),
            Registry.hands[Registry.currentPlayer],
            Registry.hands[GetVisiblePlayer(Registry.currentPlayer, Registry.declarer)],
            Registry.contractStrain,
            Registry.contractLevel
        );
    }

    int GetDummyPosition(int currentPlayer, int declarer) {
        return 0; // TODO! FILL ME IN!
    }

    int GetVisiblePlayer(int currentPlayer, int declarer) {
        return 0; // TODO! FILL ME IN! DO WE NEED THIS FUNCTION AS WELL AS THE ONE ABOVE?
    }
}
