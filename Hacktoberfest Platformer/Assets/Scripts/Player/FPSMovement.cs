using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class FPSMovement : MonoBehaviour
{
    //Singleton Reference
    public static FPSMovement instance; 
    public Rigidbody rb;
    public Animator animator;
    public Transform viewCam;
    [SerializeField]
    private PlayerInput playerInput;

    [Range(1, 10)]
    public float moveSpeed = 5f;
    [Range(0,1)]
    public float mouseSensitivity = 0.1f;

    public Vector3 movementInput { get; set; }
    public Vector2 reversedMovementInput { get; set; }

    //Private Variables
    private Vector2 rotationInput;
    private Vector3 moveHorizontal;
    private Vector3 moveVertical;
    //Angles that stop the player from looking 360 degrees behind them
    private float maxLookAngle = 160;
    private float minLookAngle = 10;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        //Tranform rotation here for smooth camera movement
        //we use tranform to rotate the entire body left and right
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z - rotationInput.x * mouseSensitivity);
        
        //Find the rotation of the camera on the y (up and down)
        Vector3 RotAmount = viewCam.transform.localRotation.eulerAngles + new Vector3(0f, rotationInput.y * mouseSensitivity, 0f);

        //Rotate camera itself by this amount so we dont turn body, also use clamp to prevent from rotating neck infinitely
        viewCam.transform.localRotation = Quaternion.Euler(RotAmount.x, Mathf.Clamp(RotAmount.y, minLookAngle, maxLookAngle), RotAmount.z);
    }

    private void FixedUpdate()
    {
        //Adjust the movement so we are always moving forward in the correct direction
        //If we lose this, we will only move forward in world not locally
        //Also we use a - for x because it flips our lefts and rights correctly
        moveHorizontal = transform.up * -movementInput.x;
        moveVertical = transform.right * movementInput.y;

        //If we are trying to move
        if (movementInput != Vector3.zero)
        {
            Debug.Log("Moving");

            //Multiply our movement vectors by speed
            rb.velocity = (moveVertical + moveHorizontal)* moveSpeed;
            animator.SetBool("Running", true);
        }
        else
        {
            rb.velocity = Vector2.zero;

            animator.SetBool("Running", false);
        }

        


    }

    #region ControllerCallbacks
    ///-///////////////////////////////////////////////////////////
    ///
    public void OnLook(CallbackContext inputValue)
    {

            rotationInput = inputValue.ReadValue<Vector2>();
    }
    ///-///////////////////////////////////////////////////////////
    ///
    public void OnMove(CallbackContext inputValue)
    {
        movementInput = inputValue.ReadValue<Vector2>();
    }


    ///-///////////////////////////////////////////////////////////
    ///
    public void OnFire(CallbackContext inputValue)
    {

        //Debug.LogFormat("firing");
        //attackAnimator.SetBool("isAttacking", true);

    }
    #endregion
}
