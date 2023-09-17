using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(TMP_Text))]
public class InteractiveText : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private float _transparency;
    private float _initialTransparency;

    private TMP_Text _text;

    private void Awake()
    {
        _text = GetComponent<TMP_Text>();

        _initialTransparency = 1f;
        _text.color = new Color(_text.color.r, _text.color.g, _text.color.b, _initialTransparency);
    }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        _text.color = new Color(_text.color.r, _text.color.g, _text.color.b, _transparency);
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        _text.color = new Color(_text.color.r, _text.color.g, _text.color.b, _initialTransparency);
    }
}
