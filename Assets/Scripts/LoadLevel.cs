using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class LoadLevel : MonoBehaviour
{
    [SerializeField] GeneralGameData gameData;
    [SerializeField] Image platformSprite;
    [SerializeField] List<LevelID> Levels;

    private void OnEnable()
    {
        foreach (LevelID level in Levels)
        {
            if (level.ID == gameData.SelectedLevelID)
            {
                level.gameObject.SetActive(true);
                break;
            }
        }
        platformSprite.sprite = gameData.PlatformSkins.FirstOrDefault(x => x.IsSelected)?.sprite;
    }
}
