using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlatformSkin
{
    public Sprite sprite;
    public bool IsOpen;
    public bool IsSelected;
}
[Serializable]
public class PlatformSkins
{
    public List<PlatformSkin> skinList;
}
