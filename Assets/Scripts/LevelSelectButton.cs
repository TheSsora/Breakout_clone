using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[ExecuteAlways]
public class LevelSelectButton : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] GeneralGameData gameData;
    [SerializeField] int levelId;
    [SerializeField] TextMeshProUGUI textID;
    [SerializeField] TextMeshProUGUI textScore;
    [SerializeField] Image close;
    public void OnPointerClick(PointerEventData eventData)
    {
        LevelData levelData = gameData.GetLevelDataByID(levelId);
        if (levelData != null && levelData.IsOpen)
        {
            gameData.LoadScene(levelId);
        }        
    }
    private void OnEnable()
    {
        textScore.text = gameData.GetScoreByLevelID(levelId).ToString();

        LevelData levelData = gameData.GetLevelDataByID(levelId);
        if (levelData != null)
        {
             close.gameObject.SetActive(!levelData.IsOpen);
        }
    }
    private void OnValidate()
    {
        textID.text = levelId.ToString();
    }
}
