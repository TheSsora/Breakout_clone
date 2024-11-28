using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using static Unity.Collections.AllocatorManager;

public class InfinityBricksGenerator : MonoBehaviour
{
    [SerializeField] GameObject bricksParent;

    private Transform[] bricks;
    private IEnumerator coroutine;

    private void OnEnable()
    {
        bricks = bricksParent.GetComponentsInChildren<Transform>();
        coroutine = BrickSpawnTimeout();
        StartCoroutine(coroutine);
    }
    void SpawnBricks()
    {
        Transform[] disableBricks = bricks.Where(x => !x.gameObject.activeInHierarchy).ToArray();
        if (disableBricks != null && disableBricks.Length > 0)
        {
            int half = disableBricks.Length / 2;
            foreach (Transform brick in disableBricks)
            {
                brick.gameObject.SetActive(true);
                half--;
                if (half == 0)
                    break;
            }                       
        }        
    }
    IEnumerator BrickSpawnTimeout()
    {
        while (true)
        {
            SpawnBricks();
            yield return new WaitForSeconds(5);
        }
    }
}
