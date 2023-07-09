using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class PauseButton : MonoBehaviour
{
    public GameObject pauseMenu;
    public bool isPaused;
    public AudioSource x;
    public AudioSource y;
    public AudioSource y2;
    public AudioSource y3;



    void Start()
    {
        //pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        y.enabled = true;
        x.enabled = true;
    }

    
    void Update()
    {
        
    }
    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }
    public void ResumeGame()
    {
        pauseMenu?.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
    public void QuitGame()
    {
        Debug.Log("Good Bye");
        Application.Quit();

    }
    public void RestartGame()
    {

        Time.timeScale = 1f;
        isPaused = false;
        SceneManager.LoadScene(0);
        growthScore._growthScore = 0;
        // Restart için ayný sahneyi tekrar yüklemek yeterli olacaktý ama ayný zamanda oyun bittiðinde durduðu için isPaused boolu tekrar false hale getirildi ve oyuncu skoru da sýfýrlandý..

    }
    public void GameOver()
    {
        
        isPaused = true;
        Time.timeScale = 0f;
        x.enabled = false;
        y.enabled = false;
    }
    //Fonksiyonlar oyunu durdurma, devam ettirme, kapatma ve tekrar baþlatma özelliklerine sahip metodlar. Hepsi canvas üzerindeki buttonlara atandý isPaused metodu oyunu durdurma amacýyla kullanýldý.
   
}
