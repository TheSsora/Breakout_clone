using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class PlatformCLL : MonoBehaviour
{ 
    public float speed = 10f;
    private float screenHalfWidthInWorldUnits;

    private bool isPC = false;

    void Start()
    {
//#if UNITY_EDITOR || UNITY_STANDALONE
//        isPC = true;
//#endif
        // ���������� �������� ������ � ������� �������� ��� ����������� ��������
        float halfPaddleWidth = transform.localScale.x / 2f;
        screenHalfWidthInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize - halfPaddleWidth;
    }

    void Update()
    {
        if(YG2.envir.isDesktop)
        {
            HandlePCControls();
        }
        else
        {
            HandleMobileControls();
        }

        // ����������� ��������� � �������� ������
        float clampedX = Mathf.Clamp(transform.position.x, -screenHalfWidthInWorldUnits + transform.localScale.x, screenHalfWidthInWorldUnits - transform.localScale.x);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
    }

    void HandlePCControls()
    {
        //���������� � ������� ������� ��� ������ A / D
        float horizontalInput;// = Input.GetAxis("Horizontal"); // ���������� �������� �� -1 �� 1

        if (Input.GetKey(KeyCode.A))
        {
            horizontalInput = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            horizontalInput = 1;
        }
        else { horizontalInput = 0; }
        
        transform.Translate(Vector2.right * horizontalInput * speed * Time.deltaTime);

        // ���������� � ������� ����
        //if (Input.GetMouseButton(0)) // ���� ����� ������ ���� ������
        //{
        //    float mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition).normalized.x;

        //    if(mousePos != 0)
        //    {
        //        mousePos = mousePos > 0 ? 1 : -1;
        //    }
        //    //transform.position = new Vector3(mousePos.x, transform.position.y, transform.position.z);
        //    transform.Translate(Vector2.right * mousePos * speed * Time.deltaTime);
        //}
    }

    void HandleMobileControls()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); // ������������ ������ �����
            float touchPosition = Camera.main.ScreenToWorldPoint(touch.position).normalized.x;

            if(touchPosition != 0)
            {
                touchPosition = touchPosition > 0 ? 1 : -1;
            }
            // ���������� ��������� �� �������������� ��� � ������� �������
            //transform.position = new Vector3(touchPosition.x, transform.position.y, transform.position.z);
            transform.Translate(Vector2.right * touchPosition * speed * Time.deltaTime);
        }
    }   
}
