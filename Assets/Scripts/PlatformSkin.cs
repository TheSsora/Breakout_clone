using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlatformSkin
{
    [SerializeField] Sprite sprite;
    public bool IsOpen;
    public bool IsSelected;

    public Sprite GetSprite() { return sprite; }
}
[Serializable]
public class PlatformSkins
{
    public List<PlatformSkin> skinList;
}
