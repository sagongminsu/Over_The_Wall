using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI ���ӽ����̽� �߰�

public class CardScript : MonoBehaviour
{
    // Value of card, 2 of clubs = 2, etc
    public int value = 0;

    public int GetValueOfCard()
    {
        return value;
    }

    public void SetValue(int newValue)
    {
        value = newValue;
    }

    public string GetSpriteName()
    {
        return GetComponent<Image>().sprite.name; // Image�� ����
    }

    public void SetSprite(Sprite newSprite)
    {
        gameObject.GetComponent<Image>().sprite = newSprite; // Image�� ����
    }

    public void ResetCard()
    {
        Sprite back = GameObject.Find("Deck").GetComponent<DeckScript>().GetCardBack();
        gameObject.GetComponent<Image>().sprite = back; // Image�� ����
        value = 0;
    }
}
