using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemKey : IItemImplementation
{
    public string lockName;
    public string keyName;
    public new ItemID.ID ItemID;

    public override void Use()
    {
    }

    public ItemKey()
    {
        base.ItemID = ItemID;
        base.ItemName = keyName;
    }
}
