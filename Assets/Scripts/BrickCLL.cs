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
        if(Random.Range(0,100) <= 1 && ball != null)
        {
            Instantiate(Bonuses[Random.Range(0, Bonuses.Count - 1)], transform.position, Quaternion.identity).SetBall(ball);                      
        }
        GameManager.Instance.ScoreCLL.AddScore(brickData.Points);        
        gameObject.SetActive(false);        
    }
}
