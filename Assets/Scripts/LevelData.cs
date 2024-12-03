using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class LevelData
{
    public int ID;
    public float Score;
    public bool IsOpen;
}
[Serializable]
public class LevelsData
{
    public List<LevelData> Levels;
}