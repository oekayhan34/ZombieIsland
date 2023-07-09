using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityStandardAssets.Vehicles.Car;
public class AIController : MonoBehaviour
{
    private GameObject[] players;
    private GameObject targetPlayer;
    public NavMeshAgent theAgent;
    private bool hasStartedMove = false;
    public AudioSource audioSource;
    public AudioClip[] musicClips;
    private bool isPlayingSecondClip = false;

    private void Start()
    {
        audioSource.clip = musicClips[0]; 
        audioSource.Play();
    }

    private void Update()
    {
        
        
        if (hasStartedMove == false)
        {
            StartCoroutine(StartMoveAfterDelay());   //Update i�ine bool koyularak ilk �nce ba�lang�� animasyonu komutu veriliyor.

        }
        else
        {
            if (!isPlayingSecondClip)
            {
                audioSource.clip = musicClips[1]; 
                audioSource.Play();                               // E�er ba�lang�� animasyon ve sesi oynat�ld�ysa art�k normal Update i ne giri� yap�l�yor bunlar� yapmak i�in 1 bool ve bir if else d�ng�s� kullan�ld�.
                audioSource.loop = true;
                isPlayingSecondClip = true;
            }
            FindNearestPlayer();
            MoveTowardsTarget();
            
        }

        
    }

    private void FindNearestPlayer()
    {
        players = GameObject.FindGameObjectsWithTag("Player");

        float shortestDistance = Mathf.Infinity;

        foreach (GameObject player in players)
        {
            float distance = Vector3.Distance(transform.position, player.transform.position);   // FindNearestPlayer fonksiyonu ile Tag i Player olan objeler aras�ndan en yak�n objeyi ar�yor ve buluyor ve onu "targetPlayer" olarak tan�ml�yoruz.

            if (distance < shortestDistance)
            {
                shortestDistance = distance;
                targetPlayer = player;
                
            }
        }
    }

    private void MoveTowardsTarget()
    {
        if (targetPlayer != null )
        {
            
            this.GetComponent<Animator>().Play("Run");
            theAgent.SetDestination(targetPlayer.transform.position);   //MoveTowardsTarget fonksiyonu ile E�er targetPlayer var ise yok de�ilse ko�ma animasyonu ile hedefini var�� noktas�n� o olarak belirliyor ve pe�inden ko�uyor.
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && other.gameObject == targetPlayer)
        {
            
           
            growthScore._growthScore = 0;   //E�er yakalarsa oyuncuyu onun skorunu 0 yap�yor 


        }
    }
    private IEnumerator StartMoveAfterDelay()
    {
        
        GetComponent<Animator>().Play("Laughing");
        yield return new WaitForSeconds(5f); // Ba�lang��ta her �ey s�ras�yla olabilmesi ad�na Coroutine olu�turuldu.
        hasStartedMove = true;      
    }


}