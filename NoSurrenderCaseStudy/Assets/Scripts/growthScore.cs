using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class growthScore : MonoBehaviour
{
    public static int _growthScore;
    public GameObject growthScoreText;
    
    void Start()
    {

    }

    
    void Update()
    {
        growthScoreText.GetComponent<TextMeshProUGUI>().text = _growthScore.ToString(); // Player in scoru buradan yazdýrýldý.
    }
}
