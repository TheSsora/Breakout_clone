using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

[ExecuteAlways]
public class LevelSelectButton : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] GeneralGameData gameData;
    [SerializeField] int levelId;
    [SerializeField] TextMeshProUGUI textID;
    [SerializeField] TextMeshProUGUI textScore;
    public void OnPointerClick(PointerEventData eventData)
    {
        gameData.LoadScene(levelId);
    }
    private void OnEnable()
    {
        textScore.text = gameData.GetScoreByLevelID(levelId).ToString();
    }
    private void OnValidate()
    {
        textID.text = levelId.ToString();
    }
}
