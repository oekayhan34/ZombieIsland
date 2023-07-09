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
        startCam.SetActive(false);  //Oyun baþlangýcýnda ana AI a odaklanmak istendiði için kamera deðiþtirildi ve bunun bir süre yapýlmasý istendiðinden ötürü Coroutine oluþturuldu.
    }
}
