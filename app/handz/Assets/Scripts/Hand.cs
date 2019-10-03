using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hand : MonoBehaviour
{
    public static int NORTH = 0;
    public static int SOUTH = 1;
    public static int WEST = 2;
    public static int EAST = 3;

    public SpriteManager spriteManager;
    public int direction;
    public Image[] cardImages;

    // Start is called before the first frame update
    void Start()
    {
        // Set up card images
        List<Card> hand = Registry.hands[direction];
        for (int i=0;i < 13;i++) {
            if (hand[i].suit == Card.CLUBS) {
                cardImages[i].sprite = spriteManager.clubs[hand[i].rank];
                cardImages[i].color = new Color(0.133f, 0.694f, 0.298f);
            } else if (hand[i].suit == Card.DIAMONDS) {
                cardImages[i].sprite = spriteManager.diamonds[hand[i].rank];
                cardImages[i].color = new Color(1.0f, 0.5f, 0.153f);
            } else if (hand[i].suit == Card.HEARTS) {
                cardImages[i].sprite = spriteManager.hearts[hand[i].rank];
                cardImages[i].color = new Color(1.0f, 0.0f, 0.0f);
            } else if (hand[i].suit == Card.SPADES) {
                cardImages[i].sprite = spriteManager.spades[hand[i].rank];
                cardImages[i].color = new Color(0.0f, 0.0f, 0.0f);
            } else Debug.Log(hand[i].suit + " is not a valid suit index!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
