using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject playerGameObject;
    public Camera playerCamera;
    public CharacterController characterController;
    public GameStateManager gameState;
    // Start is called before the first frame update
    void Start()
    {
        PlayerController.Init(characterController, playerGameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameState.gameState != GameStateEnum.MAINMENU)
        {
            InputManager.Update();
        }
    }
}
