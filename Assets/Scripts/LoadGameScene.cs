using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class LoadGameScene : MonoBehaviour
{
    [SerializeField] protected GeneralGameData gameData;
    [SerializeField] Image platformSprite;
    
    protected virtual void OnEnable()
    {
        platformSprite.sprite = gameData.PlatformSkins.skinList.FirstOrDefault(x => x.IsSelected)?.sprite;
    }
}
