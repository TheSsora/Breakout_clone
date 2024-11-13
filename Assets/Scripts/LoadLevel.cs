using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLevel : MonoBehaviour
{
    [SerializeField] GeneralGameData gameData;
    [SerializeField] List<LevelID> Levels;

    private void OnEnable()
    {
        foreach (LevelID level in Levels)
        {
            if (level.ID == gameData.SelectedLevelID)
            {
                level.gameObject.SetActive(true);
            }
        }
    }
}
