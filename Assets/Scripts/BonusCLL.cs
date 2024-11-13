using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class BonusCLL : MonoBehaviour
{
    [SerializeField] BonusType type;
    [SerializeField] float bonusValue;

    [Header("Links")]
    [SerializeField] BallCLL BallPref;
    BallCLL BallBonusTrigger;

    private void OnEnable()
    {
        if (type == BonusType.AddBalls)
            GameManager.Instance.LoseCLL.AddBonus(1);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (type == BonusType.AddBalls)
        {
            GameManager.Instance.LoseCLL.AddBall(bonusValue);
            GameManager.Instance.LoseCLL.AddBonus(-1);
            for (int i = 0; i < bonusValue; ++i)
            {
                if (BallBonusTrigger != null)
                    Instantiate(BallPref, BallBonusTrigger.transform.position, Quaternion.identity).AddForce();
                else
                    Instantiate(BallPref, new Vector2(0, -2.5f), Quaternion.identity).AddForce();
            }
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (type == BonusType.AddBalls)
        {
            GameManager.Instance.LoseCLL.CheckLose(0,1);
        }
    }
    public void SetBall(BallCLL ball)
    {
        BallBonusTrigger = ball;
    }
}
public enum BonusType
{
    AddBalls = 0,
}
