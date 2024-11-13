using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCLL : MonoBehaviour
{
    [SerializeField] float BallsCount = 1;
    [SerializeField] float BonusesCount = 0;
    [SerializeField] GameObject GameOverUI;

    public void CheckLose(float ballLose, float bonusLose)
    {
        BallsCount -= ballLose;
        BonusesCount -= bonusLose;

        if (BallsCount <= 0 && BonusesCount <= 0)
        {
            GameOverUI.SetActive(true);
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
}
