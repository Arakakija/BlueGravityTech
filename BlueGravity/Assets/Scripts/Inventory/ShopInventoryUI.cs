using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopInventoryUI : InventoryUI
{
    protected override void RefreshInventory(bool shouldRefresh)
    {
        if(!shouldRefresh) return;
        for (int i = 0; i < _inventory.ListItems.Count -1 ; i++)
        {
            var slot = _GridInventory.GetChild(i);
            if(!slot) return;
            var item = _inventory.ListItems[i];
            if (item && slot.childCount != 0) 
                slot.GetComponent<ISlot>().SetupSlot(item);
            else
                if(!item && slot.childCount != 0)GameUI.Instance.pool.ReturnObjectToPool(slot.GetChild(0).GetComponent<ItemUI>());
        }
    }
}
