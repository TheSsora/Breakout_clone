using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    private bool isCreated = false;

    [SerializeField] AudioSource audioSource;
    public void Play(AudioClip audio)
    {
        audioSource.clip = audio;
        audioSource.Play();
    }
    public void Mute(bool turn)
    {
        audioSource.mute = turn;
    }
    public void Loud(float value)
    {
        audioSource.volume = value;
    }

    private void Awake()
    {
        DontDestroyOnLoad(this);

        if (instance == null)
        {            
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }    
}
