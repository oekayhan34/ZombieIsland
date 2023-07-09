using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bait : MonoBehaviour
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
            growthScore._growthScore += 1;
            print(growthScore._growthScore);
            this.gameObject.SetActive(false);  // Eðer tag i Player olan birisi girerse Player tagli kiþinin büyüme skoru her giriþte 1 artar ve bu objeyi yok olacak.

        }
    }
   
}
