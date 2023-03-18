using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ItemType
{
    Armor,
    Legs,
    Back,
    Weapon,
    Helmet
}
[CreateAssetMenu(fileName = "New Item", menuName = "Items/Item")]
public class Item : ScriptableObject
{
    [field: SerializeField] public int Id { get; private set; }
    [field: SerializeField] public Sprite Icon { get; private set; }
    [field: SerializeField] public String Name { get; private set; }
    [field: SerializeField] public String Description { get; private set; }
    [field: SerializeField] public ItemType ItemType { get; private set; }
    
    [field: SerializeField] public Sprite[] SpriteSet { get; private set; }
    [field: SerializeField] public bool IsEquipped { get; private set; }

    [field: SerializeField] public int value { get; private set; }

    public void EquipItem()
    {
        this.IsEquipped = true;
    }
    
    public void UnEquipItem()
    {
        this.IsEquipped = false;
    }
}
