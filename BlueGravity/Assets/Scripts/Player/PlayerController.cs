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

    public Action<bool> OnBuyItem;
    public Action<bool> OnSellItem;

    public IInteractable Interactable;


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Shop"))
        {
            CanInteract = true;
            Interactable = col.gameObject.GetComponent<IInteractable>();
            PlayerUI.ShowInteractButton(CanInteract);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Shop"))
        {
            CanInteract = false;
            Interactable = null;
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
        return CanBuyItem;
    }

}
