using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseInfinityCLL : LoseCLL
{
    protected override void GameOver()
    {
        GameOverUI.SetActive(true);
        GameOverScoreText.text = GameManager.Instance.ScoreCLL.GetIntScore().ToString("0");

        if (GameManager.Instance.GameData.InfinityScore < GameManager.Instance.ScoreCLL.GetIntScore())
            GameManager.Instance.GameData.InfinityScore = GameManager.Instance.ScoreCLL.GetIntScore();
    }
}
