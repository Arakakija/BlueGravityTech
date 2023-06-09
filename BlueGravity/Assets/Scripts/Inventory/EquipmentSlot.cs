using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum SlotType
{
    Armor,
    Legs,
    Back,
    Weapon1,
    Weapon2,
    Helmet
}
public class EquipmentSlot : InventorySlot
{
    [SerializeField] private ItemType _PossibleItemType;
    [field: SerializeField] public SlotType _slotType { get; private set; }

    [SerializeField] private PlayerInventoryUI _inventory;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public override void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;
        ItemUI itemUI = dropped.GetComponent<ItemUI>();
        if(!itemUI || itemUI.item.ItemType != _PossibleItemType) return;
        
        if (transform.childCount != 0)
        {
            transform.GetChild(0).SetParent(itemUI.parentAfterDrag);
        }
        
        _inventory.EquipUI(itemUI.item, _slotType);
        
        var equipment = itemUI.parentAfterDrag.GetComponent<EquipmentSlot>();
        if (equipment && itemUI.parentAfterDrag.childCount <= 0)
        {
            equipment.GetPlayerInventory().UnequipUI(
                itemUI.item, equipment._slotType);
        }

        var SellSLot = itemUI.parentAfterDrag.GetComponent<SellInventorySlot>();
        if (SellSLot)
        {
            SellSLot.GetSellInventory().RemoveItem(itemUI.item);
            SellSLot.GetSellInventoryUI().RemoveGold(itemUI.item.Value);
        }
        
        itemUI.parentAfterDrag = transform;
    }


    public PlayerInventoryUI GetPlayerInventory()
    {
        return _inventory;
    }
}
