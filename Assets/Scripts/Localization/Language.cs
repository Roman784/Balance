using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Language : MonoBehaviour
{
    public static Language Instance;

    public Languages CurrentLanguage { get; private set; }

    [SerializeField] private TranslationDictionary _dictionary;

    public static UnityEvent LanguageChanged = new UnityEvent();

    private void Awake()
    {
        if (Instance != null && Instance != this) Destroy(gameObject);
        Instance = this;
    }

    public void LoadData()
    {

    }

    public void ChangeLanguage()
    {
        CurrentLanguage = CurrentLanguage == Languages.Ru ? Languages.En : Languages.Ru;

        LanguageChanged.Invoke();
    }

    public string GetTranslate(string word)
    {
        foreach (Translation translation in _dictionary.Translations)
        {
            if (translation.En == word || translation.Ru == word)
            {
                return CurrentLanguage == Languages.Ru ? translation.Ru : translation.En;
            }
        }

        return "none";
    }
}
