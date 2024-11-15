using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "", menuName = "GeneralGameData")]
public class GeneralGameData : ScriptableObject
{
    public int SelectedLevelID;

    public SceneAsset BaseScene;
    public List<LevelData> BaseLevels;

    public void LoadScene(int levelID)
    {
        SelectedLevelID = levelID;
        SceneManager.LoadScene(BaseScene.name, LoadSceneMode.Single);
    }
    public int GetScoreByLevelID(int levelID)
    {
        foreach (LevelData level in BaseLevels)
        {
            if(level.ID == levelID) return level.Score;
        }
        Debug.LogWarning("Level ID not found!");
        return 0;
    }
    public void SetScoreByLevelID(int levelID, int score)
    {
        foreach (LevelData level in BaseLevels)
        {
            if (level.ID == levelID)
                if(level.Score < score)
                    level.Score = score;
        }
    }
}
