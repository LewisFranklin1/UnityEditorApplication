using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    //public variables
    public List<IItemInterface> items = new List<IItemInterface>();
    public Dictionary<ItemID, List<IItemInterface>> currentInventory = new Dictionary<ItemID, List<IItemInterface>>();

    //private variables

    //public methods
    InventoryManager()
    {
        BaseEventManager.pickUpItem += OnPickUp;
    }

    public void OnPickUp(IItemImplementation item)
    {
        if (currentInventory.ContainsKey(item.ItemID))
        {
            currentInventory[item.ItemID].Add(item);
        }
        else
        {
            currentInventory.Add(item.ItemID, new List<IItemInterface>());
            currentInventory[item.ItemID].Add(item);
        }
    }

    //private methods
}
