using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{   
    public float StartSpeed;
    [SerializeField] Rigidbody2D ball;
    
    public void Push()
    {
        ball.AddForce(Vector2.up * StartSpeed, ForceMode2D.Impulse);
    }
}
