using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundTurn : Setting
{    
    [SerializeField] Toggle toggle;

    private void OnEnable()
    {
        toggle.isOn = gameData.AudioIsOn;
        AudioManager.instance.Mute(!gameData.AudioIsOn);
    }
    public void Turn(bool turn)
    {
        gameData.AudioIsOn = toggle.isOn;
        AudioManager.instance.Mute(!gameData.AudioIsOn);
    }
}
