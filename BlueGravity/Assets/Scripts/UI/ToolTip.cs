using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ToolTip : MonoBehaviour
{
    [SerializeField] private Vector2 offset;
    private RectTransform rectTransform;
    private Canvas canvas;

    [SerializeField] private Image _icon;
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private TextMeshProUGUI _description;
    

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
    }

    private void Update()
    {
        Vector2 mousePos = Mouse.current.position.ReadValue();
        Vector2 localPos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, mousePos, canvas.worldCamera, out localPos))
        {
            rectTransform.localPosition = localPos + offset;
        }
    }

    public void SetupToolTip(Item item)
    {
        _icon.sprite = item.Icon;
        _name.text = item.Name;
        _description.text = item.Description;
    }
}
