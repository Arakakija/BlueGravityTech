using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private GameObject _slotPrefab;
    [SerializeField] protected Inventory _inventory;

    [SerializeField] private Transform _GridInventory;
    // Start is called before the first frame update

    private void OnEnable()
    {
        _inventory.OnBuyItem += RefreshInventory;
    }

    private void OnDestroy()
    {
        _inventory.OnBuyItem -= RefreshInventory;
    }

    void Start()
    {
        InitInventoryUI();
    }
    
    void InitInventoryUI()
    {
        foreach (var item in _inventory.ListItems)
        {
            ISlot inventorySlot =
                GameObject.Instantiate(_slotPrefab, _GridInventory).GetComponent<ISlot>();
            if(item) inventorySlot.SetupSlot(item);
        }
    }

    void RefreshInventory(bool shouldRefresh)
    {
        if(!shouldRefresh) return;
        for (int i = 0; i < _inventory.ListItems.Count; i++)
        {
            var slot = _GridInventory.GetChild(i);
            if(!slot) return;
            var item = _inventory.ListItems[i];
            if (item && slot.childCount == 0 && !item.IsEquipped) 
                slot.GetComponent<ISlot>().SetupSlot(item);
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
}
