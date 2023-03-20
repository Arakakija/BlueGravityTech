using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SellInventoryUI : InventoryUI
{
    [SerializeField] private TextMeshProUGUI Gold;
    [SerializeField] private Button sellButton;
    public int gold;
    // Start is called before the first frame update
    void Start()
    {
        gold = 0;
        RefreshGoldText();
        sellButton.onClick.AddListener(Sell);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RefreshGoldText()
    {
        Gold.text = gold.ToString();
    }
    
    public void AddGold(int amount)
    {
        gold += amount;
        RefreshGoldText();
    }

    public void RemoveGold(int amout)
    {
        gold -= amout;
        RefreshGoldText();
    }

    void Sell()
    {
        PlayerController.Instance.PlayerInventory.Sell(_inventory.ListItems);
        _inventory.EmptyList();
        ClearInventory();
        gold = 0;
        Gold.text = gold.ToString();
    }

    void ClearInventory()
    {
        for (int i = 0; i < _GridInventory.childCount - 1; i++)
        {
            if (_GridInventory.GetChild(i).childCount <= 0) continue; 
            var item = _GridInventory.GetChild(i).GetChild(0);
            if(!item) continue;
            GameUI.Instance.pool.ReturnObjectToPool(item.GetComponent<ItemUI>());

        }
    }


}
