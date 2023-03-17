using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class GameUI : Singleton<GameUI>
{
    [SerializeField] private GameObject TradeUI;
    [SerializeField] private GameObject PlayerInvetoryUI;
    [SerializeField] private GameObject ToolTipUI;

    private void Update()
    {
        
    }

    public bool IsInventoryOpen { get; private set;}

    public void ShowTradeUI(bool value)
    {
        TradeUI.SetActive(value);
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
    
    
}
