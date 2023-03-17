using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [field: SerializeField]
    public List<Item> ListItems
    {
        get; private set;
    }

    public Item FindItemAtIndex(int index)
    {
        return ListItems[index];
    }
    
    public Item FindItem(Item itemToFind)
    {
        if (ListItems.Contains(itemToFind))
            return ListItems.Find(obj => obj == itemToFind);

        return null;
    }
    
    public Item GetFirstItem()
    {
        return ListItems[0];
    }

    public void AddItem(Item itemToAdd)
    {
        ListItems.Add(itemToAdd);
    }
    
    public void RemoveItem(Item itemToAdd)
    {
        ListItems.Remove(itemToAdd);
    }
    
}
