using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Sounds"), System.Serializable]
public class Sounds : ScriptableObject
{
    public List<Sound> SoundList = new List<Sound>();
}

[System.Serializable]
public struct Sound
{
    public string Name;
    public AudioClip Clip;
}