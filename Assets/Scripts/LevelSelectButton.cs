using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LevelSelectButton : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] GeneralGameData gameData;
    [SerializeField] int levelId;
    public void OnPointerClick(PointerEventData eventData)
    {
        gameData.LoadScene(levelId);
    }    
}
