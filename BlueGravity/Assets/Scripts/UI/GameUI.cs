using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameUI : Singleton<GameUI>
{
    [SerializeField] private CanvasGroup TradeUI;
    [SerializeField] private CanvasGroup PlayerInvetoryUI;
    [SerializeField] private CanvasGroup ToolTipUI;

    [SerializeField] private InventoryUI ShopInventory;

    [field: SerializeField] public ItemUIObjectPool pool { get; private set; }

    public Action OnShopEvent;
    public Action OnCancelEvent;

    public bool IsDragging = false;
    

    public bool IsInventoryOpen { get; private set;}

    public void ShowTradeUI(bool value)
    {
        TradeUI.alpha = value ? 1 : 0;
    }

    public void SetShopUI(ShopInventory inventory)
    {
        ShopInventory.SetupShop(inventory);
    }

    public void ShowPlayerInventoryUI(bool value)
    {
        IsInventoryOpen = value;
        PlayerInvetoryUI.alpha = value ? 1 : 0;
        if(value == false && ToolTipUI.gameObject.activeInHierarchy) ShowToolTipUI(false);
    }

    public void ShowToolTipUI(bool value)
    {
        ToolTipUI.alpha = value ? 1 : 0;
    }
    
    public ToolTip GetToolTip()
    {
        return ToolTipUI.GetComponent<ToolTip>();
    }
}
