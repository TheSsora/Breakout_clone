using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using YG;

public class ScoreCLL : MonoBehaviour
{
    [SerializeField] float Score;
    [SerializeField] float scoreMultiplier = 1;
    [SerializeField] float timeout;
    [SerializeField] float multiplierRise;

    private IEnumerator coroutine;
    private void OnEnable()
    {
        coroutine = ScoreMultiplierTimeout();
    }
    public void AddScore(int value)
    {
        Score += value * scoreMultiplier;
        scoreMultiplier += multiplierRise;
        GameManager.Instance.UILinksManager.UpdateScoreMulti(scoreMultiplier);
        GameManager.Instance.UILinksManager.SetUpdateBonusTimeLine(timeout);

        if (coroutine != null)
        {
            StopCoroutine(coroutine);
            coroutine = ScoreMultiplierTimeout();
        }            
        //else
        //    coroutine = ScoreMultiplierTimeout();

        StartCoroutine(coroutine);
        GameManager.Instance.UILinksManager.UpdateScore(Score);        
    }
    public int GetIntScore()
    {
        return (int)Score;
    }
    public void SaveLevelScoreIfBetter()
    {
        if (GameManager.Instance.GameData.GetScoreByLevelID(GameManager.Instance.GameData.SelectedLevelID) < GetIntScore())
        {
            GameManager.Instance.GameData.SetScoreByLevelID(GameManager.Instance.GameData.SelectedLevelID, GetIntScore());
            GameManager.Instance.GameData.SaveLevelsData();
        }                 
    }
    public void SaveInfinityScoreIfBetter()
    {
        if (GameManager.Instance.GameData.InfinityScore < GetIntScore())
        {
            GameManager.Instance.GameData.InfinityScore = GetIntScore();
            GameManager.Instance.GameData.SaveInfinityData();
            
            YG2.SetLeaderboard("infinityScore", (int)GameManager.Instance.GameData.InfinityScore);
        }                   
    }
    IEnumerator ScoreMultiplierTimeout()
    {        
        yield return new WaitForSeconds(timeout);
        scoreMultiplier = 1;
        GameManager.Instance.UILinksManager.UpdateScoreMulti(scoreMultiplier);
        //coroutine = ScoreMultiplierTimeout();        
    }
    private void Update()
    {
        GameManager.Instance.UILinksManager.UpdateBonusTimeLine();
    }
}
