using Newtonsoft.Json;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

[CreateAssetMenu(fileName = "", menuName = "GeneralGameData")]
public class GeneralGameData : ScriptableObject
{
    [Header("Level Links")]
    public int SelectedLevelID;    
    public string BaseScene;
    public LevelsData BaseLevels;

    [Header("Infinity Game Links")]
    public string InfinityScene;
    public float InfinityScore;

    [Header("Skin Links")]
    public PlatformSkins PlatformSkins;

    [Header("Settings")]
    public bool AudioIsOn;
    public float AudioLoud;

    public void LoadScene(int levelID)
    {
        SelectedLevelID = levelID;
        SceneManager.LoadScene(BaseScene, LoadSceneMode.Single);
    }
    public void LoadInfinityScene()
    {
        SceneManager.LoadScene(InfinityScene, LoadSceneMode.Single);
    }
    public float GetScoreByLevelID(int levelID)
    {
        foreach (LevelData level in BaseLevels.Levels)
        {
            if(level.ID == levelID) return level.Score;
        }
        Debug.LogWarning("Level ID not found!");
        return 0;
    }
    public void SetScoreByLevelID(int levelID, float score)
    {
        foreach (LevelData level in BaseLevels.Levels)
        {
            if (level.ID == levelID)
                if(level.Score < score)
                    level.Score = score;
        }
    }
    public void SelectPlatformSkin(int index)
    {
        var selected = PlatformSkins.skinList.FirstOrDefault(x => x.IsSelected);
        if (selected != null)
            selected.IsSelected = false;

        if(PlatformSkins.skinList.Count < index)
            PlatformSkins.skinList[index].IsSelected = true;
    }
    public void SaveSettings()
    {
        YG2.saves.AudioIsOn = AudioIsOn;
        YG2.saves.AudioLoud = AudioLoud;

        YG2.SaveProgress();
    }
    public void SaveSkins()
    {
        YG2.saves.PlatformSkins = JsonConvert.SerializeObject(PlatformSkins);

        YG2.SaveProgress();
    }
    public void SaveLevelsData()
    {
        YG2.saves.Levels = JsonUtility.ToJson(BaseLevels);

        YG2.SaveProgress();
    }
    public void SaveInfinityData()
    {
        YG2.saves.InfinityScore = InfinityScore;

        YG2.SaveProgress();
    }
    public void LoadData()
    {
        JsonUtility.FromJsonOverwrite(YG2.saves.PlatformSkins, PlatformSkins);
        JsonUtility.FromJsonOverwrite(YG2.saves.Levels, BaseLevels);
        InfinityScore = YG2.saves.InfinityScore;
        AudioIsOn = YG2.saves.AudioIsOn;
        AudioLoud = YG2.saves.AudioLoud;
    }
}
