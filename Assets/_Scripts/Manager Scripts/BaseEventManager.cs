using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BaseEventManager
{
    public delegate void OnItemInteractionDelegate(Collider collider, float distance);
    public static event OnItemInteractionDelegate onItemInteraction;

    public static void OnItemInteraction(Collider collider, float distance)
    {
        onItemInteraction?.Invoke(collider, distance);
    }

    public delegate void InGameMouse0InteractionDelegate(Collider collider, float distance);
    public static event InGameMouse0InteractionDelegate inGameMouse0Interaction;

    public static void OnInGameMouse0Interaction(Collider collider, float distance)
    {
        inGameMouse0Interaction?.Invoke(collider, distance);
    }

    public delegate void InGameMouse1InteractionDelegate(Collider collider);
    public static event InGameMouse1InteractionDelegate inGameMouse1Interaction;

    public static void OnInGameMouse1Interaction(Collider collider)
    {
        inGameMouse1Interaction?.Invoke(collider);
    }
}
