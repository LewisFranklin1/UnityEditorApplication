using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IItemImplementation : MonoBehaviour, IItemInterface
{ 
    public ushort Durability { get; set; }
    public string ItemName { get; set; }
    public ItemID ItemID { get; set; }

    public virtual void Use()
    {

    }
}