using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InputManager
{
    static RaycastHit raycastHit;
    static Camera playerCamera;
    public static void Init(Camera camera)
    {
        playerCamera = camera;
    }
    // Update is called once per frame
    public static void Update()
    {
        if(Input.anyKeyDown)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (fireRaycast())
                {
                    BaseEventManager.OnItemInteraction(raycastHit.collider, raycastHit.distance);
                }
            }
            else if (Input.GetKeyDown(KeyCode.Tab))
            {
                if(GameStateManager.Instance.gameState == GameStateEnum.INVENTORY)
                {
                    GameStateManager.Instance.ChangeGameState(GameStateEnum.MAINGAME);
                }
                else if(GameStateManager.Instance.gameState == GameStateEnum.MAINGAME)
                {
                    GameStateManager.Instance.ChangeGameState(GameStateEnum.INVENTORY);
                }
                PlayerController.ChangeCursorMode();
            }
            else if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (GameStateManager.Instance.gameState == GameStateEnum.MAINGAME)
                {
                    GameStateManager.Instance.ChangeGameState(GameStateEnum.PAUSEMENU);
                }
                else if (GameStateManager.Instance.gameState == GameStateEnum.PAUSEMENU)
                {
                    GameStateManager.Instance.ChangeGameState(GameStateEnum.MAINGAME);
                }
            }
        }
        else if(Input.GetMouseButton(0))
        {
            if (fireRaycast())
            {
                BaseEventManager.OnInGameMouse0Interaction(raycastHit.collider, raycastHit.distance);
            }
        }
        else if (Input.GetMouseButton(1))
        {
            if (fireRaycast())
            {
                BaseEventManager.OnInGameMouse1Interaction(raycastHit.collider);
            }
        }
        PlayerController.Update();
    }

    private static bool fireRaycast()
    {
        return Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out raycastHit, Mathf.Infinity);
    }
}
