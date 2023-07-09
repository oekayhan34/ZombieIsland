using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadPlayer : MonoBehaviour
{
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            growthScore._growthScore = 0;
            other.transform.position = new Vector3(78.0100021f, 9.82999992f, 26.75f);    // Eðer tag i "Player" olan obje buraya tetiklenir ise score u 0 olacak ve tekrardan yeniden doðma suretiyle position ve rotationu belirli noktalara gelir.
            other.transform.rotation = Quaternion.Euler(0, 0, 0);
        }    
    }
}
