using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonCLL : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] AudioClip clip;
    public void OnPointerClick(PointerEventData eventData)
    {
        AudioManager.instance.Play(clip);
    }        
}
