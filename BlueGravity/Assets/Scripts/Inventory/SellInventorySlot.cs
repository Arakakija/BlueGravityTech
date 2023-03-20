using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SellInventorySlot : InventorySlot
{
    [SerializeField] private SellInventoryUI _inventoryUI;
    public override void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;
        ItemUI itemUI = dropped.GetComponent<ItemUI>();
        if(!itemUI) return;
        
        if (transform.childCount != 0)
        {
            transform.GetChild(0).SetParent(itemUI.parentAfterDrag);
        }

        var equipment = itemUI.parentAfterDrag.GetComponent<EquipmentSlot>();
        if (equipment && itemUI.parentAfterDrag.childCount <= 0)
        {
            equipment.GetPlayerInventory().UnequipUI(
                itemUI.item, equipment._slotType);
        }
        
        _inventoryUI.GetInventory().AddRefItem(itemUI.item);
        _inventoryUI.AddGold(itemUI.item.Value);
        
        itemUI.parentAfterDrag = transform;
    }

    public Inventory GetSellInventory()
    {
        return _inventoryUI.GetInventory();
    }
    
    public SellInventoryUI GetSellInventoryUI()
    {
        return _inventoryUI;
    }
}
