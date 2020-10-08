using System;
using UnityEngine;

public interface  IItemInterface
{
    ushort Durability { get; set; }
    string ItemName { get; set; }
    ItemID ItemID { get; set; }

    //void PickUp(Vector3 vector3);
    void Use();
    
}