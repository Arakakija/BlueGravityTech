using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopSlot : MonoBehaviour, ISlot
{
    private Item _itemOnSlot;

    [SerializeField] private Image _image;

    [SerializeField] private TextMeshProUGUI _name;

    [SerializeField] private TextMeshProUGUI _description;
    [SerializeField] private TextMeshProUGUI _value;

    [SerializeField] private Button _buyButton;

    private void Start()
    {
        _buyButton.onClick.AddListener(Buy);
    }
    
    public void SetupSlot(Item item)
    {
        _itemOnSlot = item;
        _image.sprite = _itemOnSlot.Icon;
        _name.text = _itemOnSlot.Name;
        _description.text = _itemOnSlot.Description;
        _value.text = "$" + _itemOnSlot.Value.ToString();
    }

    private void Buy()
    {
        PlayerController.Instance.PlayerInventory.Buy(_itemOnSlot);
    }
}
