using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class TopDownMovement : MonoBehaviour
{
    Vector2 movementInput;
    Vector2 rotationInput;
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private Rigidbody2D swordRB;
    [SerializeField]
    private Animator playerAnimator;
    [SerializeField]
    private Animator attackAnimator;
    [SerializeField]
    private PlayerInput playerInput;
    public float moveSpeed = 1f;

    public float collisionOffset = 0.05f;

    public ContactFilter2D movementFilter;

    private bool isFacingRight = true;
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
            int count = rb.Cast(movementInput, movementFilter, castCollisions, moveSpeed * Time.fixedDeltaTime + collisionOffset);

            Debug.LogFormat("count {0}", count);
            if (count == 0)
            {
                rb.MovePosition(rb.position + movementInput * moveSpeed * Time.fixedDeltaTime);
            }

        }

        Flip();
    }

    ///-///////////////////////////////////////////////////////////
    ///
    private void Flip()
    {
        // Flip our GameObject everyTime we change direction
        if (isFacingRight && movementInput.x < 0f || isFacingRight == false && movementInput.x > 0f)
        {
            //Invert Transform of object
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
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

        Debug.LogFormat("firing");
        attackAnimator.SetBool("isAttacking", true);

    }
    #endregion


}
