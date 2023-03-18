using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventoryUI : InventoryUI
{
    private void Start()
    {
        InitInventoryUI();
    }

    public void EquipUI(Item item,SlotType slotType)
    {
        item.EquipItem();
        _inventory.RemoveItem(item);
        switch (slotType)
        {
            case SlotType.Helmet:
                PlayerController.Instance.PlayerInventory.HelmetHolder.sprite = item.SpriteSet[0];
                break;
            case SlotType.Armor:
                PlayerController.Instance.PlayerInventory.ArmorHolder.sprite = item.SpriteSet[0];
                PlayerController.Instance.PlayerInventory.Shoulder1Holder.sprite = item.SpriteSet[1];
                PlayerController.Instance.PlayerInventory.Shoulder2Holder.sprite = item.SpriteSet[2];
                break;
            case SlotType.Legs:
                PlayerController.Instance.PlayerInventory.Legs1Holder.sprite = item.SpriteSet[0];;
                PlayerController.Instance.PlayerInventory.Legs2Holder.sprite = item.SpriteSet[1];;
                break;
            case SlotType.Weapon1:
                PlayerController.Instance.PlayerInventory.WeaponHolder1.sprite = item.SpriteSet[0];
                break;
            case SlotType.Weapon2:
                PlayerController.Instance.PlayerInventory.WeaponHolder2.sprite = item.SpriteSet[0];
                break;
            
        }
    }

    public void UnequipUI(Item item,SlotType slotType)
    {
        item.UnEquipItem();
        _inventory.AddItemAtFirstEmpty(item);
        switch (slotType)
        {
            case SlotType.Helmet:
                PlayerController.Instance.PlayerInventory.HelmetHolder.sprite = null;
                break;
            case SlotType.Armor:
                PlayerController.Instance.PlayerInventory.ArmorHolder.sprite = null;
                PlayerController.Instance.PlayerInventory.Shoulder1Holder.sprite = null;
                PlayerController.Instance.PlayerInventory.Shoulder2Holder.sprite = null;
                break;
            case SlotType.Legs:
                PlayerController.Instance.PlayerInventory.Legs1Holder.sprite = null;
                PlayerController.Instance.PlayerInventory.Legs2Holder.sprite = null;
                break;
            case SlotType.Weapon1:
                PlayerController.Instance.PlayerInventory.WeaponHolder1.sprite = null;
                break;
            case SlotType.Weapon2:
                PlayerController.Instance.PlayerInventory.WeaponHolder2.sprite = null;
                break;
        }
    }
}
