using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class TopDownMovement : MonoBehaviour
{
    public Vector2 movementInput {get; private set;}
    Vector2 rotationInput;
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private Animator playerAnimator;
    [SerializeField]
    private Animator attackAnimator;
    [SerializeField]
    private PlayerInput playerInput;
    public float moveSpeed = 1f;
    [SerializeField]
    Health health;
    [SerializeField]
    Transform weapon;
    public float collisionOffset = 0.05f;

    public ContactFilter2D movementFilter;

    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();


    ///-///////////////////////////////////////////////////////////
    ///
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    ///-///////////////////////////////////////////////////////////
    ///
    private void Update()
    {
        UpdateMovementAnimation();
        
    }

    ///-///////////////////////////////////////////////////////////
    ///
    void FixedUpdate()
    {

        if (movementInput != Vector2.zero)
        {
            //The number of objects we can collide with if we go in this direction
            int count = rb.Cast(movementInput, movementFilter, castCollisions, moveSpeed * Time.fixedDeltaTime + collisionOffset);

            //if nothing is in the way, move our character
            if (count == 0)
            {
                rb.MovePosition(rb.position + movementInput * moveSpeed * Time.fixedDeltaTime);
            }

        }

        HandleRotation(rotationInput);

        Flip(movementInput, GetComponent<SpriteRenderer>());
    }



    ///-///////////////////////////////////////////////////////////
    ///
    void HandleRotation(Vector2 direction)
    {
        direction.Normalize();

        Vector2 v = direction;


        v = Vector2.ClampMagnitude(v, 6);
        Vector2 newLocation = (Vector2)transform.position + v;

        if (direction != Vector2.zero)
        {
            weapon.position = Vector2.Lerp(weapon.position, newLocation, 10 * Time.deltaTime);

            //Look at player
            Flip(direction, weapon.gameObject.GetComponentInChildren<SpriteRenderer>());
        }
        

    }
    ///-///////////////////////////////////////////////////////////
    ///
    private void Flip(Vector2 input, SpriteRenderer sr)
    {

        if(input.x > 0f)
        {
            sr.flipX = false;
        }
        else if(input.x < 0f)
        {
            sr.flipX = true;
        }
    }

    ///-///////////////////////////////////////////////////////////
    ///
    void UpdateMovementAnimation()
    {
        if (movementInput != Vector2.zero)
        {
            playerAnimator.SetBool("isRunning", true);
        }
        else
        {
            playerAnimator.SetBool("isRunning", false);
        }

    }


    #region ControllerCallbacks
    ///-///////////////////////////////////////////////////////////
    ///
    public void OnLook(CallbackContext inputValue)
    {
        if (inputValue.ReadValue<Vector2>() != Vector2.zero)
        {
            rotationInput = inputValue.ReadValue<Vector2>();
        }

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
        attackAnimator.SetBool("isAttacking", true);

    }
    #endregion


}
