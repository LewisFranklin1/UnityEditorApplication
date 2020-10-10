using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerController
{
    //public variables


    //private variables
    private static CharacterController localCharacterController;
    private static GameObject localPlayerGameObject;
    private static Transform cameraTransform;
    private static Vector3 movement;
    private static Vector2 rotation;
    public static float moveVelcoity;
    public static float jumpVelocity;
    public static float gravitationalPull;
    public static float mouseSensitivity;
    public static float upLimit = -50.0f;
    public static float downLimit = 50.0f;

    // Start is called before the first frame update
    public static void Init(CharacterController characterController, GameObject player)
    {   
        localCharacterController = characterController;
        localPlayerGameObject = player;
        cameraTransform = localPlayerGameObject.GetComponentInChildren<Camera>().transform;
        Cursor.visible = true;
        moveVelcoity = 100.0f;
        jumpVelocity = 2.0f;
        gravitationalPull = 1.0f;
        mouseSensitivity = 2.0f;
        movement = Vector3.zero;
    }
    public static void ChangeCursorMode()
    {
        if (Cursor.visible)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        
    }
    // Update is called once per frame
    public static void Update()
    {
        if (Cursor.visible == false)
        {
            Move();
            Rotate();
            //Vector3 movementDirection = (camPointer.forward * -Input.GetAxis("Vertical") * verticalSpeed) +
            //    (camPointer.right * -Input.GetAxis("Horizontal") * horizontalSpeed);
            //controller.Move(movementDirection * Time.deltaTime);
            //movementDirection.y = 0;
            //transform.rotation = Quaternion.LookRotation(new Vector3(-movementDirection.z, 0, movementDirection.x));

            //movement.Set(1, 1, 1);
            //movement.Scale((Input.GetAxisRaw("Horizontal") * localPlayerGameObject.transform.right) + (Input.GetAxisRaw("Vertical") * localPlayerGameObject.transform.forward));

            //localCharacterController.Move(movement * moveVelcoity * Time.deltaTime);
            //Debug.Log(movement * moveVelcoity * Time.deltaTime);
            //localCharacterController.Move(Vector3.down * gravitationalPull * Time.deltaTime);
            //Debug.Log("X: " + localCharacterController.gameObject.transform.position.x + " Z: " + localCharacterController.gameObject.transform.position.z);
        }
        //Debug.Log(Cursor.visible);
    }
    public static void Move()
    {
        if (localCharacterController.isGrounded)
        {
            // We are grounded, so recalculate
            // move direction directly from axes

            movement = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            movement *= moveVelcoity;

            if (Input.GetButton("Jump"))
            {
                movement.y = jumpVelocity;
            }
        }

        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        movement.y -= gravitationalPull * Time.deltaTime;

        // Move the controller
        localCharacterController.SimpleMove(movement * Time.deltaTime);
        //movement.x = Input.GetAxis("Horizontal");
        //movement.z = Input.GetAxis("Vertical");

        ////if (localCharacterController.isGrounded)
        ////{
        ////    movement.y = 0;
        ////}
        ////else
        ////{
        ////    movement.y -= gravitationalPull * Time.deltaTime;
        ////}
        //movement = localPlayerGameObject.transform.forward * movement.z + localPlayerGameObject.transform.right * movement.x;
        //localCharacterController.Move(moveVelcoity * Time.deltaTime * movement);
    }

    private static void Rotate()
    {
        rotation.x = Input.GetAxis("Mouse X");
        rotation.y = Input.GetAxis("Mouse Y");

        localPlayerGameObject.transform.Rotate(0, rotation.x * mouseSensitivity, 0);
        cameraTransform.Rotate(-rotation.y * mouseSensitivity, 0, 0);
        Vector3 currentRotation = cameraTransform.localEulerAngles;
        if(currentRotation.x > 180.0f)
        {
            currentRotation.x -= 360.0f;
        }
        currentRotation.x = Mathf.Clamp(currentRotation.x, upLimit, downLimit);
        cameraTransform.localRotation = Quaternion.Euler(currentRotation);
    }
}
