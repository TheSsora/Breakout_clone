using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class LoadLevel : LoadGameScene
{    
    [SerializeField] List<LevelID> Levels;

    override protected void OnEnable()
    {
        base.OnEnable();
        foreach (LevelID level in Levels)
        {
            if (level.ID == gameData.SelectedLevelID)
            {
                level.gameObject.SetActive(true);
                break;
            }
        }        

        GameManager.Instance.LoseCLL.LoadBricksCount();
    }
}
