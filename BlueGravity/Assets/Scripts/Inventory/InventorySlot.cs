using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler,IDropHandler,ISlot
{
    [FormerlySerializedAs("_itemUI")] [SerializeField] private GameObject _itemUIGO;
    public void OnPointerEnter(PointerEventData eventData)
    {
        if(GameUI.Instance.IsDragging || !GetItem()) return;
        GameUI.Instance.ShowToolTipUI(true);
        GameUI.Instance.GetToolTip().SetupToolTip(GetItem());
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GameUI.Instance.ShowToolTipUI(false);
    }

    public void SetupSlot(Item item)
    {
        ItemUI itemUI = GameObject.Instantiate(_itemUIGO, this.transform).GetComponent<ItemUI>();
        itemUI.SetupItemUI(item);
    }

    public virtual void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;
        ItemUI itemUI = dropped.GetComponent<ItemUI>();
        if(!itemUI) return;
        if (transform.childCount != 0)
        {
            transform.GetChild(0).SetParent(itemUI.parentAfterDrag);
        }
        
        if (itemUI.parentAfterDrag.GetComponent<EquipmentSlot>() && itemUI.parentAfterDrag.childCount <= 0)
        {
            itemUI.parentAfterDrag.GetComponent<EquipmentSlot>().GetPlayerInventory().UnequipUI(
                itemUI.item, itemUI.parentAfterDrag.GetComponent<EquipmentSlot>()._slotType);
        }
        itemUI.parentAfterDrag = transform;
    }

    private Item GetItem()
    {
        if(transform.childCount > 0)
            return GetComponentInChildren<ItemUI>().item;

        return null;
    }
    
}
