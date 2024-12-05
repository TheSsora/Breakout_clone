using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{  
    public static GameManager Instance;    

    public GeneralGameData GameData;
    [SerializeField] string MainScene;

    public LoseCLL LoseCLL;
    public UILinksManager UILinksManager;
    public ScoreCLL ScoreCLL;
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
        SceneManager.LoadScene(MainScene, LoadSceneMode.Single);
    }
    public void Pause(bool turn)
    {
        if(turn)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1.0f;
        }
        
    }
}
