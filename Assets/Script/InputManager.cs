using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class InputManager : MonoBehaviour
{

    [SerializeField] PlayerControl playerControls;

    public Vector2 movementInput;
    Vector2 cameraInput;

    public float vertical;
    public float horizonal;
    public void OnEnable() 
    {
        if(playerControls == null)
        {
            playerControls = new PlayerControl();
            playerControls.PlayerMovement.Movement.performed += inputAction => movementInput = inputAction.ReadValue<Vector2>();
            playerControls.PlayerMovement.Camera.performed += i => cameraInput = i.ReadValue<Vector2>();
             
        }
        playerControls.Enable();
    }
    private void OnDisable()
    {
        playerControls.Disable();
    }
    public void HandleAllInput()
    {
        HandleMovementInput();
        //handlejump
        //handleaction
    }
    private void HandleMovementInput()
    {
        vertical = movementInput.y;
        horizonal = movementInput.x;


    }
}
