using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private GameObject _slotPrefab;
    [SerializeField] protected Inventory _inventory;

    [SerializeField] protected Transform _GridInventory;
    // Start is called before the first frame update


    protected void InitInventoryUI()
    {
        foreach (var item in _inventory.ListItems)
        {
            ISlot inventorySlot =
                GameObject.Instantiate(_slotPrefab, _GridInventory).GetComponent<ISlot>();
            if(item) inventorySlot.SetupSlot(item);
        }
    }

    protected virtual void RefreshInventory(bool shouldRefresh)
    {
        if(!shouldRefresh) return;
        for (int i = 0; i < _inventory.ListItems.Count -1 ; i++)
        {
            var slot = _GridInventory.GetChild(i);
            if(!slot) return;
            var item = _inventory.ListItems[i];
            if (item && slot.childCount == 0 && !item.IsEquipped) 
                slot.GetComponent<ISlot>().SetupSlot(item);
            else
                if(!item && slot.childCount != 0)GameUI.Instance.pool.ReturnObjectToPool(slot.GetChild(0).GetComponent<ItemUI>());
        }
        
       
    }

    Transform GetFirstEmptySlot()
    {
        for (int i = 0; i < _GridInventory.childCount; i++)
        {
            if (_GridInventory.GetChild(i).childCount <= 0)
            {
                return _GridInventory.GetChild(i);
            }
        }
        return null;
    }

    public void SetupShop(ShopInventory inventoryToSet)
    {
        _inventory = inventoryToSet;
        if (_inventory.ListItems.Count == _GridInventory.childCount)
        {
            RefreshInventory(true);
            return;
        } 
        InitInventoryUI();
    }

    public Inventory GetInventory()
    {
        return _inventory;
    }
}
