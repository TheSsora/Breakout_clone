using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoseCLL : MonoBehaviour
{
    [SerializeField] float BallsCount = 1;
    [SerializeField] float BonusesCount = 0;
    [SerializeField] protected GameObject GameOverUI;
    [SerializeField] protected TextMeshProUGUI GameOverScoreText;

    public void CheckLose(float ballLose, float bonusLose)
    {
        BallsCount -= ballLose;
        BonusesCount -= bonusLose;

        if (BallsCount <= 0 && BonusesCount <= 0)
        {
            GameOver();
        }               
    }
    public void AddBall(float value)
    {
        BallsCount += value;
    }
    public void AddBonus(float value)
    {
        BonusesCount += value;
    }
    protected virtual void GameOver()
    {
        GameOverUI.SetActive(true);
        GameOverScoreText.text = GameManager.Instance.ScoreCLL.GetIntScore().ToString();

        GameManager.Instance.ScoreCLL.SaveLevelScoreIfBetter();

        Time.timeScale = 0;
    }
}
