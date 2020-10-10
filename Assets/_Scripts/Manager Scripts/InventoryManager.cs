using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InventoryManager
{
    //public variables
    public static int amountOfItem;
    //public static List<IItemInterface> items = new List<IItemInterface>();
    public static Dictionary<IItemInterface, int> itemsDictionarty = new Dictionary<IItemInterface, int>();
    public static Dictionary<ItemID.ID, Dictionary<IItemInterface, int>> currentInventory = new Dictionary<ItemID.ID, Dictionary<IItemInterface, int>>();

    //private variables
    private static Dictionary<IItemInterface, int> retrieveItemsDictionary;
    //public methods
    public static void Init()
    {

    }
    //private methods
    internal static void AddItemToInventory(IItemInterface item)
    {
        
        if (item.ItemID != ItemID.ID.DEFAULT)
        {
            if (currentInventory.ContainsKey(item.ItemID))
            {
                //currentInventory.TryGetValue(item.ItemID, out retrieveItemsDictionary);
                if (itemsDictionarty.ContainsKey(item))
                {
                    itemsDictionarty[item] += 1;
                }
                //currentInventory.se
                //currentInventory[item.ItemID].(item,);
            }
            else
            {
                var newItemList = new List<IItemInterface>();
                newItemList.Add(item);
                //currentInventory.Add(item.ItemID, newItemList);
                //currentInventory[item.ItemID] = newItemList;
            }
        }
        else
        {
            Debug.Log("itemID null");
        }
        var newList = new List<IItemInterface>();
        ///currentInventory.TryGetValue(ItemID.ID.DEFAULT, out newList);
        Debug.Log(newList[0].ItemName);
    }

    internal static void RemoveItemFromInventory(IItemInterface item)
    {

        if (item.ItemID != ItemID.ID.DEFAULT)
        {
            if (currentInventory.ContainsKey(item.ItemID))
            {
                //currentInventory.TryGetValue(item.ItemID, out retrieveItemsDictionary);
                if (itemsDictionarty.ContainsKey(item))
                {
                    if(itemsDictionarty[item]>0)
                    {
                        itemsDictionarty[item] -= 1;
                    }      
                }
                //currentInventory.se
                //currentInventory[item.ItemID].(item,);
            }
            else
            {
                var newItemList = new List<IItemInterface>();
                newItemList.Add(item);
                //currentInventory.Add(item.ItemID, newItemList);
                //currentInventory[item.ItemID] = newItemList;
            }
        }
        else
        {
            Debug.Log("itemID null");
        }
        var newList = new List<IItemInterface>();
        //currentInventory.TryGetValue(ItemID.ID.DEFAULT, out newList);
        Debug.Log(newList[0].ItemName);
    }
}
