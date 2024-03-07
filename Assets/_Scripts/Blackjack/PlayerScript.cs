using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    // --- This script is for BOTH player and dealer

    // Get other scripts
    public CardScript cardScript;
    public DeckScript deckScript;

    // Total value of player/dealer's hand
    public int handValue = 0;

    // Reference to GoldManager
    public GoldManager goldManager;

    // Array of card objects on table
    public GameObject[] hand;
    // Index of next card to be turned over
    public int cardIndex = 0;
    // Tracking aces for 1 to 11 conversions
    List<CardScript> aceList = new List<CardScript>();

    public void StartHand()
    {
        GetCard();
        GetCard();
    }

    // Add a hand to the player/dealer's hand
    public int GetCard()
    {
        // Get a card, use deal card to assign sprite and value to card on table
        int cardValue = deckScript.DealCard(hand[cardIndex].GetComponent<CardScript>());
        // Show card on game screen
        hand[cardIndex].GetComponent<Image>().enabled = true;
        // Add card value to running total of the hand
        handValue += cardValue;
        // If value is 1, it is an ace
        if (cardValue == 1)
        {
            aceList.Add(hand[cardIndex].GetComponent<CardScript>());
        }
        // Check if we should use an 11 instead of a 1
        AceCheck();
        cardIndex++;
        return handValue;
    }

    // Search for needed ace conversions, 1 to 11 or vice versa
    public void AceCheck()
    {
        // for each ace in the list check
        foreach (CardScript ace in aceList)
        {
            if (handValue + 10 < 22 && ace.GetValueOfCard() == 1)
            {
                // if converting, adjust card object value and hand
                ace.SetValue(11);
                handValue += 10;
            }
            else if (handValue > 21 && ace.GetValueOfCard() == 11)
            {
                // if converting, adjust gameobject value and hand value
                ace.SetValue(1);
                handValue -= 10;
            }
        }
    }

    // Output player's current money amount
    public int GetMoney()
    {
        // Use gold value from GoldManager
        return goldManager.Gold;
    }

    // Adjust gold amount
    public void AdjustGold(int amount)
    {
        // Use AdjustGold method from GoldManager
        goldManager.AdjustGold(amount);
    }

    // Hides all cards, resets the needed variables
    public void ResetHand()
    {
        for (int i = 0; i < hand.Length; i++)
        {
            hand[i].GetComponent<CardScript>().ResetCard();
            hand[i].GetComponent<Image>().enabled = false;
        }
        cardIndex = 0;
        handValue = 0;
        aceList = new List<CardScript>();
    }

    // 딜러의 두 번째 카드를 공개하거나 가려둡니다.
    public void RevealFirstCard(bool reveal)
    {
        if (hand[1] != null) // 두 번째 카드가 존재하는 경우에만 처리합니다.
        {
            // 두 번째 카드를 공개하거나 가려둡니다.
            hand[1].GetComponent<Image>().enabled = reveal;
        }
    }

    public void RevealAllCards()
    {
        for (int i = 0; i < hand.Length; i++)
        {
            hand[i].GetComponent<Image>().enabled = true;
        }
    }
}
