using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickCLL : MonoBehaviour
{
    public BrickData brickData;
    [SerializeField] List<BonusCLL> Bonuses;

    private float destroyCount;
    private void OnEnable()
    {
        destroyCount = brickData.DestroyCount;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(brickData.IsDestroyable)
        {
            if(destroyCount == 0)
            {
                DisableBrick(collision.gameObject.GetComponent<BallCLL>());
            }
            else
            {
                destroyCount--;
            }
        }        
    }
    private void DisableBrick(BallCLL ball)
    {
        BonusSpawn(ball);
        GameManager.Instance.ScoreCLL.AddScore(brickData.Points);
        GameManager.Instance.LoseCLL.DisableBrick();
        gameObject.SetActive(false);        
    }
    private void BonusSpawn(BallCLL ball)
    {
        if (Random.Range(0f, 100f) <= 5f / GameManager.Instance.LoseCLL.GetBallsCount() && ball != null)
        {
            Instantiate(Bonuses[Random.Range(0, Bonuses.Count - 1)], transform.position, Quaternion.identity).SetBall(ball);
        }
    }
}
