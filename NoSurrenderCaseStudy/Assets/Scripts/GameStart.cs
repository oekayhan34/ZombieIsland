using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    public GameObject playerCam;
    public GameObject startCam;
    
    void Start()
    {
        StartCoroutine(startingGame());
    }

    
    void Update()
    {
        
    }
    IEnumerator startingGame()
    {
        startCam.SetActive(true);
        playerCam.SetActive(false);
        yield return new WaitForSeconds(5f);
        playerCam.SetActive(true);
        startCam.SetActive(false);  //Oyun ba�lang�c�nda ana AI a odaklanmak istendi�i i�in kamera de�i�tirildi ve bunun bir s�re yap�lmas� istendi�inden �t�r� Coroutine olu�turuldu.
    }
}
