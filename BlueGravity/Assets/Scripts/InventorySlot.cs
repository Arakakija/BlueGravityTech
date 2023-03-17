using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        GameUI.Instance.ShowToolTipUI(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GameUI.Instance.ShowToolTipUI(false);
    }
}
