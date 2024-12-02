using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UILinksManager : MonoBehaviour
{    
    [SerializeField] TextMeshProUGUI scoreText;
    
    public void UpdateScore(float score)
    {
        //Score += score;
        scoreText.text = score.ToString("0");
    }    
}
