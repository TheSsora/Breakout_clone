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
}
