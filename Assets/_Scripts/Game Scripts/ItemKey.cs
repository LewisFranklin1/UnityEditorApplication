using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemKey : IItemImplementation
{
    public string lockName { get; private set; }

    public override void Use()
    {

    }

    public ItemKey()
    {
        BaseEventManager.onItemInteraction += BaseEventManagerOnItemInteraction;
    }

    private void BaseEventManagerOnItemInteraction(Collider collider, float distance)
    {
        if (this != null)
        {
            if (this.GetComponentsInChildren<BoxCollider>() != null)
            {
                foreach (var childColliders in this.GetComponentsInChildren<BoxCollider>())
                {
                    if (childColliders.name == collider.name)
                    {
                        PickUpItem(distance);
                    }
                }
            }
            else if (this.GetComponent<BoxCollider>() != null)
            {
                if (collider == this.GetComponentInChildren<BoxCollider>())
                {
                    PickUpItem(distance);
                }
            }
            else
            {
                Debug.Log(string.Format("No box collider on game item: " + this.gameObject.name));
            }
        }
    }

    private void PickUpItem(float distance)
    {
        Debug.Log(distance);
        if (distance < 100)
        {

            DestroyImmediate(this.gameObject);
        }
    }
}
