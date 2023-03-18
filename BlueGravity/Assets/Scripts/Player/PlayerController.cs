using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Singleton<PlayerController>
{
    public float speed = 5.0f;
    public float gold = 500.0f;

    public bool isGrounded;

    public bool CanInteract;

    [field: SerializeField] public PlayerUI PlayerUI { get; private set; }
    [field: SerializeField] public PlayerInventory PlayerInventory { get; private set; }

    public event Action<bool> OnBuyItem;


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Shop"))
        {
            CanInteract = true;
            PlayerUI.ShowInteractButton(CanInteract);
            GameUI.Instance.SetShopUI(col.gameObject.GetComponent<Inventory>());
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Shop"))
        {
            CanInteract = false;
            PlayerUI.ShowInteractButton(CanInteract);
        }
    }

    public bool BuyItem(Item item)
    {
        bool CanBuyItem = item.Value <= gold;
        if (CanBuyItem)
        {
            gold -= item.Value;
            if (gold < 0) gold = 0;
        }
        OnBuyItem?.Invoke(CanBuyItem);
        return CanBuyItem;
    }

}
