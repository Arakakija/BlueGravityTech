using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Image _icon;
    public void OnPointerEnter(PointerEventData eventData)
    {
        GameUI.Instance.ShowToolTipUI(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GameUI.Instance.ShowToolTipUI(false);
    }

    public void SetupSlot(Item item)
    {
        _icon.sprite = item.Icon;
    }
}
