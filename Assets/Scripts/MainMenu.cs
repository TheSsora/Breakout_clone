using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GeneralGameData gameData;
    private void OnEnable()
    {
        gameData.UpdateLevels();
        gameData.SaveLevelsData();
    }
}
