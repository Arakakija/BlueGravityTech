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
    [field: SerializeField] public Sprite Icon { get; private set; }
    [field: SerializeField] public String Name { get; private set; }
    [field: SerializeField] public String Description { get; private set; }
    [field: SerializeField] public ItemType ItemTypeType { get; private set; }
}
