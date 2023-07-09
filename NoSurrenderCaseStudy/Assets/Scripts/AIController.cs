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
            StartCoroutine(StartMoveAfterDelay());   //Update içine bool koyularak ilk önce baþlangýç animasyonu komutu veriliyor.

        }
        else
        {
            if (!isPlayingSecondClip)
            {
                audioSource.clip = musicClips[1]; 
                audioSource.Play();                               // Eðer baþlangýç animasyon ve sesi oynatýldýysa artýk normal Update i ne giriþ yapýlýyor bunlarý yapmak için 1 bool ve bir if else döngüsü kullanýldý.
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
            float distance = Vector3.Distance(transform.position, player.transform.position);   // FindNearestPlayer fonksiyonu ile Tag i Player olan objeler arasýndan en yakýn objeyi arýyor ve buluyor ve onu "targetPlayer" olarak tanýmlýyoruz.

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
            theAgent.SetDestination(targetPlayer.transform.position);   //MoveTowardsTarget fonksiyonu ile Eðer targetPlayer var ise yok deðilse koþma animasyonu ile hedefini varýþ noktasýný o olarak belirliyor ve peþinden koþuyor.
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && other.gameObject == targetPlayer)
        {
            
           
            growthScore._growthScore = 0;   //Eðer yakalarsa oyuncuyu onun skorunu 0 yapýyor 


        }
    }
    private IEnumerator StartMoveAfterDelay()
    {
        
        GetComponent<Animator>().Play("Laughing");
        yield return new WaitForSeconds(5f); // Baþlangýçta her þey sýrasýyla olabilmesi adýna Coroutine oluþturuldu.
        hasStartedMove = true;      
    }


}