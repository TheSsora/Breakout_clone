using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkinSelectorCLL : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] int ID;
    [SerializeField] GeneralGameData gameData;
    [SerializeField] Image skinSprite;
    [SerializeField] Image closedTexture;

    [SerializeField] Image iconUI;
    [SerializeField] Sprite iconSpriteSelected;
    [SerializeField] Sprite iconSpriteDeselected;

    private PlatformSkin platformSkin;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (platformSkin != null)
        {
            if(platformSkin.IsOpen && !platformSkin.IsSelected)
            {
                gameData.PlatformSkins.skinList.FirstOrDefault(x => x.IsSelected).IsSelected = false;

                platformSkin.IsSelected = true;
            }
        }
        transform.parent.GetComponentsInChildren<SkinSelectorCLL>().ToList().ForEach(x => x.UpdateUI());        
    }    
    private void OnEnable()
    {
        if (ID < gameData.PlatformSkins.skinList.Count)
        {
            platformSkin = gameData.PlatformSkins.skinList[ID];            
        }

        UpdateUI();
    }    
    private void OnValidate()
    {
        if(ID < gameData.PlatformSkins.skinList.Count)
        {
            platformSkin = gameData.PlatformSkins.skinList[ID];            
        }

        UpdateUI();
    }
    
    public void UpdateUI()
    {        
        if(platformSkin != null)
        {
            skinSprite.sprite = platformSkin.sprite;
            closedTexture.gameObject.SetActive(!platformSkin.IsOpen);
            if(platformSkin.IsSelected)
            {
                iconUI.sprite = iconSpriteSelected;
            }
            else
            {
                iconUI.sprite = iconSpriteDeselected;
            }            
        }               
    }
}
