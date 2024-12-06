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
        // Определяем половину экрана в мировых единицах для ограничения движения
        float halfPaddleWidth = transform.localScale.x / 2f;
        screenHalfWidthInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize - halfPaddleWidth;
    }

    void Update()
    {
        if (YG2.envir.isDesktop)
        {
            if (Input.GetMouseButton(0))
            {
                HandleControls(Input.mousePosition);
            }
        }
        else
        {
            if (Input.touchCount > 0)
            {
                HandleControls(Input.GetTouch(0).position);
            }
        }
        
        // Ограничение платформы в пределах экрана
        float clampedX = Mathf.Clamp(transform.position.x, -screenHalfWidthInWorldUnits + transform.localScale.x, screenHalfWidthInWorldUnits - transform.localScale.x);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
    }

    void HandleControls(Vector3 position)
    {
        Vector3 mousePos = new Vector3(Camera.main.ScreenToWorldPoint(position).x, transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, mousePos, speed * Time.deltaTime);
    }

    //void HandleMobileControls()
    //{
    //    if (Input.touchCount > 0)
    //    {            
    //        Vector3 touchPosition;            

    //        touchPosition = new Vector3(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position).x, transform.position.y, transform.position.z); ;
    //        transform.position = Vector3.Lerp(transform.position, touchPosition, speed * Time.deltaTime);
    //    }
    //}   
}
