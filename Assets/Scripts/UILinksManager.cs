using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UILinksManager : MonoBehaviour
{
    public static UILinksManager Instance;

    public int Score;
    [SerializeField] TextMeshProUGUI scoreText;

    private void Awake()
    {
        Instance = this;
    }
    public void UpdateScore(int score)
    {
        Score += score;
        scoreText.text = Score.ToString();
    }    
}
