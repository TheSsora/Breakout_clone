using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseInfinityCLL : LoseCLL
{
    protected override void GameOver()
    {
        GameOverUI.SetActive(true);
        GameOverScoreText.text = GameManager.Instance.ScoreCLL.GetIntScore().ToString("0");

        GameManager.Instance.ScoreCLL.SaveInfinityScoreIfBetter();

        Time.timeScale = 0;
    }
}
