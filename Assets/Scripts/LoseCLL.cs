using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class LoseCLL : MonoBehaviour
{
    [SerializeField] GameObject Levels;
    private GameObject BricksParent;
    [SerializeField] private float BricksCount;
    [SerializeField] float BallsCount = 1;
    [SerializeField] float BonusesCount = 0;
    [SerializeField] protected GameObject GameOverUI;
    [SerializeField] protected TextMeshProUGUI GameOverScoreText;

    private int DebugCOunter = 0;
    protected virtual void OnEnable()
    {        
        BricksParent = Levels.GetComponentsInChildren<Transform>().FirstOrDefault(x => x.gameObject.activeInHierarchy)?.gameObject;
        BricksCount = BricksParent.GetComponentsInChildren<BrickCLL>().ToList().Where(x => x.brickData.IsDestroyable).Count();
    }
    public float GetBallsCount()
    {
        return BallsCount;
    }
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
    public virtual void DisableBrick()
    {
        Debug.Log(DebugCOunter + " " + BricksCount);
        DebugCOunter++;
        BricksCount--;
        if(BricksCount <= 0)
        {
            GameOver();
        }
    }
    protected virtual void GameOver()
    {
        GameOverUI.SetActive(true);
        GameOverScoreText.text = GameManager.Instance.ScoreCLL.GetIntScore().ToString();

        GameManager.Instance.ScoreCLL.SaveLevelScoreIfBetter();

        Time.timeScale = 0;
    }
}
