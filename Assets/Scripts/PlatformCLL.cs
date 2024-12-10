using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using YG;

public class PlatformCLL : MonoBehaviour
{ 
    public float speed = 10f;
    private float screenHalfWidthInWorldUnits;    
    void Start()
    {
        // ���������� �������� ������ � ������� �������� ��� ����������� ��������
        float halfPaddleWidth = transform.localScale.x / 2f;
        screenHalfWidthInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize - halfPaddleWidth;
    }

    void Update()
    {
        if (YG2.envir.isDesktop)
        {
            MovePlatform(new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, transform.position.y, transform.position.z));
        }
        else
        {
            if (Input.touchCount > 0)
            {
                foreach (Touch touch in Input.touches)
                {
                    // ����������, ���� �������� �����
                    if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
                    {
                        if (touch.position.x < Screen.width / 2) // ����� �������� ������
                        {
                            MovePlatform(transform.position + Vector3.right * -1); // ������� ��������� �����
                        }
                        else if (touch.position.x > Screen.width / 2) // ������ �������� ������
                        {
                            MovePlatform(transform.position + Vector3.right * 1); // ������� ��������� ������
                        }
                    }
                }
            }
        }
        
        // ����������� ��������� � �������� ������
        
    }       
    void MovePlatform(Vector3 targetPosition)
    {
        transform.position = Vector3.Lerp(transform.position, targetPosition, speed * Time.deltaTime);
        float clampedX = Mathf.Clamp(transform.position.x, -screenHalfWidthInWorldUnits + transform.localScale.x, screenHalfWidthInWorldUnits - transform.localScale.x);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
    }    
}
