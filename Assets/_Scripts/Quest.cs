using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Quest
{
    public string name;

    public GameObject[] items;

    public abstract void IsAbleToFinish();
}
