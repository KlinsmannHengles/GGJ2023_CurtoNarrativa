using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WhoSpeak { NPC, PLAYER}
[System.Serializable]
public class Dialogue
{
    public string name;

    public WhoSpeak whoSpeak;

    [TextArea(2, 3)]
    public string[] sentences;
}
