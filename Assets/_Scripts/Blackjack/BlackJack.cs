using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BlackJack : MonoBehaviour
{
    public GoldManager goldManager;

    // Game Buttons
    public Button dealBtn;
    public Button hitBtn;
    public Button standBtn;
    public Button betBtn;
    public Button quitBtn;
    private int standClicks = 0;

    // Access the player and dealer's script
    public PlayerScript playerScript;
    public PlayerScript dealerScript;

    // public Text to access and update - hud
    public Text scoreText;
    public Text dealerScoreText;
    public Text betsText;
    public Text cashText;
    public Text mainText;
    public Text standBtnText;

    public TextMeshProUGUI goldText;
    // Card hiding dealer's 2nd card
    public GameObject hideCard;
    // How much is bet
    int pot = 0;

    void Start()
    {
        // Add on click listeners to the buttons
        dealBtn.onClick.AddListener(() => DealClicked());
        hitBtn.onClick.AddListener(() => HitClicked());
        standBtn.onClick.AddListener(() => StandClicked());
        betBtn.onClick.AddListener(() => BetClicked());
        quitBtn.onClick.AddListener(() => QuitGame());
        UpdateGoldUI(); // 시작할 때 UI 업데이트
    }

    private void DealClicked()
    {
        // Reset round, hide text, prep for new hand
        playerScript.ResetHand();
        dealerScript.ResetHand();
        // Hide deal hand score at start of deal
        dealerScoreText.gameObject.SetActive(false);
        mainText.gameObject.SetActive(false);
        dealerScoreText.gameObject.SetActive(false);
        GameObject.Find("Deck").GetComponent<DeckScript>().Shuffle();
        playerScript.StartHand();
        dealerScript.StartHand();
        // Update the scores displayed
        scoreText.text = "Hand: " + playerScript.handValue.ToString();
        // 딜러의 첫 번째 카드를 공개하고 두 번째 카드는 가려둡니다.
        dealerScoreText.text = "Hand: " + dealerScript.handValue.ToString();
        dealerScript.RevealFirstCard(false);
        // Place card back on dealer card, hide card
        hideCard.GetComponent<Image>().enabled = true;
        // Adjust buttons visibility
        dealBtn.gameObject.SetActive(false);
        hitBtn.gameObject.SetActive(true);
        standBtn.gameObject.SetActive(true);
        standBtnText.text = "Stand";
        // Set standard pot size
        pot = 40;
        betsText.text = "Bets: $" + pot.ToString();
        playerScript.AdjustGold(-20);
        cashText.text = "$" + playerScript.GetMoney().ToString();
    }

    private void HitClicked()
    {
        // Check that there is still room on the table
        if (playerScript.cardIndex <= 10)
        {
            playerScript.GetCard();
            scoreText.text = "Hand: " + playerScript.handValue.ToString();
            if (playerScript.handValue > 20) RoundOver();
        }
    }

    private void StandClicked()
    {
        standClicks++;
        if (standClicks > 1) RoundOver();
        HitDealer();
        standBtnText.text = "Call";
        // 딜러의 두 번째 카드를 공개합니다.
        dealerScript.RevealFirstCard(true);
    }

    private void HitDealer()
    {
        while (dealerScript.handValue < 16 && dealerScript.cardIndex < 10)
        {
            dealerScript.GetCard();
            dealerScoreText.text = "Hand: " + dealerScript.handValue.ToString();
            if (dealerScript.handValue > 20) RoundOver();
        }
    }
    private void RoundOver()
    {
        // Booleans (true/false) for bust and blackjack/21
        bool playerBust = playerScript.handValue > 21;
        bool dealerBust = dealerScript.handValue > 21;
        bool player21 = playerScript.handValue == 21;
        bool dealer21 = dealerScript.handValue == 21;

        // 플레이어가 버스트되었을 때 딜러의 모든 카드를 공개합니다.
        if (playerBust)
        {
            dealerScript.RevealAllCards();
        }

        // If stand has been clicked less than twice, no 21s or busts, quit function
        if (standClicks < 2 && !playerBust && !dealerBust && !player21 && !dealer21) return;
        bool roundOver = true;
        // All bust, bets returned
        if (playerBust && dealerBust)
        {
            mainText.text = "All Bust: Bets returned";
            playerScript.AdjustGold(pot / 2);
        }
        // if player busts, dealer didn't, or if dealer has more points, dealer wins
        else if (playerBust || (!dealerBust && dealerScript.handValue > playerScript.handValue))
        {
            mainText.text = "Dealer wins!";
        }
        // if dealer busts, player didn't, or player has more points, player wins
        else if (dealerBust || playerScript.handValue > dealerScript.handValue)
        {
            mainText.text = "You win!";
            playerScript.AdjustGold(pot);
        }
        //Check for tie, return bets
        else if (playerScript.handValue == dealerScript.handValue)
        {
            mainText.text = "Push: Bets returned";
            playerScript.AdjustGold(pot / 2);
        }
        else
        {
            roundOver = false;
        }
        // Set UI up for next move / hand / turn
        if (roundOver)
        {
            hitBtn.gameObject.SetActive(false);
            standBtn.gameObject.SetActive(false);
            dealBtn.gameObject.SetActive(true);
            mainText.gameObject.SetActive(true);
            dealerScoreText.gameObject.SetActive(true);
            hideCard.GetComponent<Image>().enabled = false;
            cashText.text = "$" + playerScript.GetMoney().ToString();
            standClicks = 0;
        }
    }


    // Add money to pot if bet clicked
    void BetClicked()
    {
        Text newBet = betBtn.GetComponentInChildren(typeof(Text)) as Text;
        int intBet = int.Parse(newBet.text.ToString().Remove(0, 1));
        playerScript.AdjustGold(-intBet);

        // GoldManager에서 Gold 속성 변경
        goldManager.Gold -= intBet;

        UpdateGoldUI(); // UI 업데이트
    }

    // UI에 현재 골드 반영
    public void UpdateGoldUI()
    {
        goldText.text = goldManager.Gold.ToString();
    }
    void QuitGame()
    {
        // 마우스 락 설정
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // BlackJackCanvas 게임 오브젝트 비활성화
        GameObject blackJackCanvas = GameObject.Find("BlackJackCanvas");
        if (blackJackCanvas != null)
        {
            blackJackCanvas.SetActive(false);
        }
    }
}
