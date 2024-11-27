using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "", menuName = "GeneralGameData")]
public class GeneralGameData : ScriptableObject
{
    [Header("Level Links")]
    public int SelectedLevelID;    
    public SceneAsset BaseScene;
    public List<LevelData> BaseLevels;

    [Header("Infinity Game Links")]
    public SceneAsset InfinityScene;
    public int InfinityScore;

    [Header("Skin Links")]
    public List<PlatformSkin> PlatformSkins;

    [Header("Settings")]
    public bool AudioIsOn;
    public float AudioLoud;

    public void LoadScene(int levelID)
    {
        SelectedLevelID = levelID;
        SceneManager.LoadScene(BaseScene.name, LoadSceneMode.Single);
    }
    public void LoadInfinityScene()
    {
        SceneManager.LoadScene(InfinityScene.name, LoadSceneMode.Single);
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
    public void SelectPlatformSkin(int index)
    {
        var selected = PlatformSkins.FirstOrDefault(x => x.IsSelected);
        if (selected != null)
            selected.IsSelected = false;

        if(PlatformSkins.Count < index)
            PlatformSkins[index].IsSelected = true;
    }
}
