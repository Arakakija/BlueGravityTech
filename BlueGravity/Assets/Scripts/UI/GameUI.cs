using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameUI : Singleton<GameUI>
{
    [SerializeField] private GameObject TradeUI;
    [SerializeField] private GameObject PlayerInvetoryUI;
    [SerializeField] private GameObject ToolTipUI;

    [SerializeField] private InventoryUI ShopInventory;

    [field: SerializeField] public ItemUIObjectPool pool { get; private set; }

    public Action OnShopEvent;
    public Action OnCancelEvent;

    public bool IsDragging = false;
    

    public bool IsInventoryOpen { get; private set;}

    public void ShowTradeUI(bool value) 
    {
        TradeUI.SetActive(value);
    }

    public void SetShopUI(Inventory inventory)
    {
        ShopInventory.SetupShop(inventory);
    }

    public void ShowPlayerInventoryUI(bool value)
    {
        IsInventoryOpen = value;
        PlayerInvetoryUI.SetActive(value);
        if(value == false && ToolTipUI.gameObject.activeInHierarchy) ShowToolTipUI(false);
    }

    public void ShowToolTipUI(bool value)
    {
        ToolTipUI.SetActive(value);
    }
    
    public ToolTip GetToolTip()
    {
        return ToolTipUI.GetComponent<ToolTip>();
    }
}
