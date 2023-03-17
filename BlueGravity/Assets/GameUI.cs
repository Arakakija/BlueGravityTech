using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : Singleton<GameUI>
{
    [SerializeField] private GameObject TradeUI;
    [SerializeField] private GameObject PlayerInvetoryUI;

    public bool IsInventoryOpen { get; private set;}

    public void ShowTradeUI(bool value)
    {
        TradeUI.SetActive(value);
    }

    public void ShowPlayerInventoryUI(bool value)
    {
        IsInventoryOpen = value;
        PlayerInvetoryUI.SetActive(value);
    }
}
