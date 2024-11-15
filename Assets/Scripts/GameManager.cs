using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{  
    public static GameManager Instance;

    public int Score;

    public GeneralGameData GameData;
    [SerializeField] SceneAsset MainScene;

    public LoseCLL LoseCLL;
    public UILinksManager UILinksManager;
    private void Awake()
    {
        Instance = this;       
    }
    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);        
    }    
    public void Exit()
    {
        SceneManager.LoadScene(MainScene.name, LoadSceneMode.Single);
    }
}
