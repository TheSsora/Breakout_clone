using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class LoadGameScene : MonoBehaviour
{
    [SerializeField] protected GeneralGameData gameData;
    [SerializeField] GameObject platform;
    
    protected virtual void OnEnable()
    {
        platform.transform.GetChild(gameData.PlatformSkins.skinList.FindIndex(x => x.IsSelected)).gameObject.SetActive(true);        

        Time.timeScale = 0;
    }
}
