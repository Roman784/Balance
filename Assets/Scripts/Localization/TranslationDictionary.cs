using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Translations"), System.Serializable]
public class TranslationDictionary : ScriptableObject
{
    public List<Translation> Translations = new List<Translation>();
}

[System.Serializable]
public struct Translation
{
    public string En;
    public string Ru;
}