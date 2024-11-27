using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundLoud : Setting
{
    [SerializeField] Slider slider;

    private void OnEnable()
    {
        slider.value = gameData.AudioLoud;
    }
    public void LoudChange()
    {
        gameData.AudioLoud = slider.value;
        AudioManager.instance.Loud(gameData.AudioLoud);
    }
}
