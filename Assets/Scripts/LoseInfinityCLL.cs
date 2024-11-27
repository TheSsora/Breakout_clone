using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseInfinityCLL : LoseCLL
{
    protected override void GameOver()
    {
        GameOverUI.SetActive(true);
        GameOverScoreText.text = GameManager.Instance.Score.ToString();

        if (GameManager.Instance.GameData.InfinityScore < GameManager.Instance.Score)
            GameManager.Instance.GameData.InfinityScore = GameManager.Instance.Score;
    }
}
