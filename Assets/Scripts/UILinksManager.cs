using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UILinksManager : MonoBehaviour
{    
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI multiText;
    [SerializeField] Slider bonusTime;
    
    public void UpdateScore(float score)
    {
        //Score += score;
        scoreText.text = score.ToString("0");
    }
    public void UpdateScoreMulti(float multi)
    {
        multiText.text = multi.ToString("x0.00");
    }
    public void SetUpdateBonusTimeLine(float value)
    {
        bonusTime.value = value;
    }
    public void UpdateBonusTimeLine()
    {
        bonusTime.value -= Time.deltaTime;
    }
}
