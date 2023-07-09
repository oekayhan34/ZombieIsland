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
       //Eðer süre 0 deðilse süre sürekli azalacak ve eðer sýfýr olursa oyun bitmiþ olacak gameOverMenu gelecek oyuncunun skoru yazdýrýlacak ve GameOver metoduna oyunun durmasý amacýyla ulaþýlacak.


        UpdateTimeText();
    }

    private void UpdateTimeText()
    {
        int minutes = Mathf.FloorToInt(countdownTimer / 60f);
        int seconds = Mathf.FloorToInt(countdownTimer % 60f);

        // Dakika ve saniye ayrýmýna yapabilmek adýna 60a bölünüp 60dan geri kalaný alýndý ve bunlar minutes ve seconds olarak tanýmlandý ve sonra ise bir text üzeriinden yazdýrýldý.
        string timeString = minutes.ToString("00") + ":" + seconds.ToString("00");

        timeText.text = timeString;
    }
}
