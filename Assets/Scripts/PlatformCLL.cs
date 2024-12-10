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
        // Определяем половину экрана в мировых единицах для ограничения движения
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
                    // Определяем, куда касается игрок
                    if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
                    {
                        if (touch.position.x < Screen.width / 2) // Левая половина экрана
                        {
                            MovePlatform(transform.position + Vector3.right * -1); // Двигаем платформу влево
                        }
                        else if (touch.position.x > Screen.width / 2) // Правая половина экрана
                        {
                            MovePlatform(transform.position + Vector3.right * 1); // Двигаем платформу вправо
                        }
                    }
                }
            }
        }
        
        // Ограничение платформы в пределах экрана
        
    }       
    void MovePlatform(Vector3 targetPosition)
    {
        transform.position = Vector3.Lerp(transform.position, targetPosition, speed * Time.deltaTime);
        float clampedX = Mathf.Clamp(transform.position.x, -screenHalfWidthInWorldUnits + transform.localScale.x, screenHalfWidthInWorldUnits - transform.localScale.x);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
    }    
}
