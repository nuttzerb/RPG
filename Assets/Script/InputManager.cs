using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class InputManager : MonoBehaviour
{

    [SerializeField] PlayerControl playerControls;
    AnimatorManager animatorManager;

    public Vector2 movementInput;
    private float moveAmount;
    public float verticalInput;
    public float horizonalInput;
    public void Awake()
    {
        animatorManager = GetComponent<AnimatorManager>();
    }
    public void OnEnable() 
    {
        if(playerControls == null)
        {
            playerControls = new PlayerControl();
            playerControls.PlayerMovement.Movement.performed += inputAction => movementInput = inputAction.ReadValue<Vector2>();
          //  playerControls.PlayerMovement.Camera.performed += i => cameraInput = i.ReadValue<Vector2>();
             
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
        verticalInput = movementInput.y;
        horizonalInput = movementInput.x;
        moveAmount = Mathf.Clamp01(Mathf.Abs(horizonalInput) + Mathf.Abs(verticalInput));
        animatorManager.UpdateAnimatorValues(0, moveAmount);

    }
}
