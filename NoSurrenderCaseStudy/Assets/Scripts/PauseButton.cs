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
        // Restart i�in ayn� sahneyi tekrar y�klemek yeterli olacakt� ama ayn� zamanda oyun bitti�inde durdu�u i�in isPaused boolu tekrar false hale getirildi ve oyuncu skoru da s�f�rland�..

    }
    public void GameOver()
    {
        
        isPaused = true;
        Time.timeScale = 0f;
        x.enabled = false;
        y.enabled = false;
    }
    //Fonksiyonlar oyunu durdurma, devam ettirme, kapatma ve tekrar ba�latma �zelliklerine sahip metodlar. Hepsi canvas �zerindeki buttonlara atand� isPaused metodu oyunu durdurma amac�yla kullan�ld�.
   
}
