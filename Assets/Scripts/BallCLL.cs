using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCLL : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float speed = 3;
    public void AddForce()
    {
        rb.AddForce(new Vector2(Random.Range(-1f, 1f), Random.Range(0f, 1f)).normalized * speed, ForceMode2D.Impulse);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer.Equals(LayerMask.NameToLayer("Platform")))
        {
            // ������������ ����� ��������
            float hitPoint = (transform.position.x - collision.transform.position.x) / collision.collider.bounds.size.x;

            // ��������� ������ � ����������� �� ����� ��������
            Vector2 direction = new Vector2(hitPoint, 1).normalized;
            rb.velocity = direction * speed;
        }
        if (collision.gameObject.layer.Equals(LayerMask.NameToLayer("Wall")))
        {
            if (rb.velocity.y <= 0.05f || rb.velocity.y >= -0.05f)
            {
                rb.velocity = new Vector2(rb.velocity.normalized.x, rb.velocity.normalized.y + -0.2f).normalized * speed;
            }
            if (rb.velocity.normalized.y >= 0.95f)
            {
                rb.velocity = new Vector2(-rb.velocity.normalized.x + 0.3f, rb.velocity.normalized.y - 0.3f).normalized * speed;
            }
        }
        if (collision.gameObject.layer.Equals(LayerMask.NameToLayer("Brick")))
        {
            if (rb.velocity.normalized.y >= 0.95f)
            {
                rb.velocity = new Vector2(-rb.velocity.normalized.x + 0.2f, rb.velocity.normalized.y - 0.2f).normalized * speed;
            }
            else if (rb.velocity.normalized.x >= 0.95f)
            {
                rb.velocity = new Vector2(rb.velocity.normalized.x - 0.2f, rb.velocity.normalized.y + 0.2f).normalized * speed;
            }
            if (rb.velocity.magnitude != speed)
            {
                if(rb.velocity.magnitude == 0)
                {
                    rb.velocity = new Vector2(Random.Range(-1f, 1f), Random.Range(0f, 1f)).normalized * speed;
                }
                else
                {
                    rb.velocity = rb.velocity.normalized * speed;
                }                
            }
        }        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer.Equals(LayerMask.NameToLayer("LoseTrigger")))
        {
            GameManager.Instance.LoseCLL.CheckLose(1,0);
            Destroy(gameObject);
        }
    }    
}
