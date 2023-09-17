using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class TextTranslater : MonoBehaviour
{
    [SerializeField] private string _en;
    [SerializeField] private string _ru;

    private TMP_Text _text;

    private void Start()
    {
        _text = GetComponent<TMP_Text>();

        Language.LanguageChanged.AddListener(UpdateText);

        UpdateText();
    }

    private void UpdateText() => _text.text = Language.Instance.CurrentLanguage == Languages.Ru ? _ru : _en;
}
