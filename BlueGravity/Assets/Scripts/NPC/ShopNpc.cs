using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopNpc : MonoBehaviour,IInteractable
{
    [SerializeField] private ShopInventory _inventory;
    
    public void Interact()
    {
        GameUI.Instance.SetShopUI(_inventory);
    }
}
