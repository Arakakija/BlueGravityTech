using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Inventory : MonoBehaviour
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
        ListItems.Add(Instantiate(itemToAdd));
    }
    
    public void AddRefItem(Item itemToAdd)
    {
        ListItems.Add(itemToAdd);
    }
    
    public void AddItemAtFirstEmpty(Item itemToAdd)
    {
        for (int i = 0; i < ListItems.Count; i++)
        {
            if(ListItems[i]) continue;
            ListItems[i] = Instantiate(itemToAdd);
            break;
        }
    }
    
    public void RemoveItem(Item itemToAdd)
    {
        ListItems.Remove(itemToAdd);
    }
    
    public void EmptyList()
    {
        ListItems.Clear();
    }
}
    

