using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Camera playerCamera;
    public CharacterController characterController;
    public GameStateManager gameState;
    // Start is called before the first frame update
    void Start()
    {
        InputManager.Init(playerCamera, characterController);
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
