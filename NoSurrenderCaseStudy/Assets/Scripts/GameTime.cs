using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameTime : MonoBehaviour
{
    public TMP_Text timeText;
    public float countdownDuration = 240f; // 4 minutes in seconds
    private float countdownTimer;
    public static bool gameOver = false;
    public GameObject gameOverMenu;
    public GameObject pauseButton;
    public GameObject GameOverText;
    
    private void Start()
    {
        countdownTimer = countdownDuration;
        UpdateTimeText();
    }

    private void Update()
    {
        if (countdownTimer != 0)
        {
            countdownTimer -= Time.deltaTime;

            if (countdownTimer <= 0f)
            {

                countdownTimer = 0f;

            }
        }
        else
        {
            gameOverMenu.SetActive(true);
            pauseButton.GetComponent<PauseButton>().GameOver();
            GameOverText.GetComponent<TextMeshProUGUI>().text = "Your Score : " + growthScore._growthScore.ToString();
        }
       //E�er s�re 0 de�ilse s�re s�rekli azalacak ve e�er s�f�r olursa oyun bitmi� olacak gameOverMenu gelecek oyuncunun skoru yazd�r�lacak ve GameOver metoduna oyunun durmas� amac�yla ula��lacak.


        UpdateTimeText();
    }

    private void UpdateTimeText()
    {
        int minutes = Mathf.FloorToInt(countdownTimer / 60f);
        int seconds = Mathf.FloorToInt(countdownTimer % 60f);

        // Dakika ve saniye ayr�m�na yapabilmek ad�na 60a b�l�n�p 60dan geri kalan� al�nd� ve bunlar minutes ve seconds olarak tan�mland� ve sonra ise bir text �zeriinden yazd�r�ld�.
        string timeString = minutes.ToString("00") + ":" + seconds.ToString("00");

        timeText.text = timeString;
    }
}
