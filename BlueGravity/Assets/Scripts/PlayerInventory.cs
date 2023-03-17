using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInventory : Inventory
{
    [field: SerializeField] public SpriteRenderer HelmetHolder { get; private set; }
    [field: SerializeField] public SpriteRenderer ArmorHolder{ get; private set; }
    [field: SerializeField] public SpriteRenderer Shoulder1Holder{ get; private set; }
    [field: SerializeField] public SpriteRenderer Shoulder2Holder{ get; private set; }
    [field: SerializeField] public SpriteRenderer Legs1Holder{ get; private set; }
    [field: SerializeField] public SpriteRenderer Legs2Holder{ get; private set; }
    [field: SerializeField] public SpriteRenderer WeaponHolder1{ get; private set; }
    [field: SerializeField] public SpriteRenderer WeaponHolder2{ get; private set; }
}
