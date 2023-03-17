using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private GameObject _slotPrefab;
    [SerializeField] private Inventory _inventory;

    [SerializeField] private Transform _GridInventory;
    // Start is called before the first frame update
    void Start()
    {
        InitInventoryUI();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InitInventoryUI()
    {
        foreach (var item in _inventory.ListItems)
        {
            InventorySlot inventorySlot =
                GameObject.Instantiate(_slotPrefab, _GridInventory).GetComponent<InventorySlot>();
            inventorySlot.SetupSlot(item);
        }
    }
}
