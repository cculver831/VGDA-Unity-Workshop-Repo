using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class PlayerMovement : MonoBehaviour
{

    private float horizontal;
    [SerializeField]
    [Range(0, 20)]
    private float speed = 8f;
    [SerializeField][Range(0, 50)]
    private float jumpingPower = 16f;
    private bool isFacingRight = true;
    private bool doubleJump;
    [Header("Player Movement Variables")]
    [SerializeField] private  Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Animator animator;


    // Update is called once per frame
    void Update()
    {


        Debug.LogFormat("double jump {0}", doubleJump);
        if (IsGrounded())
        {
            animator.SetBool("Jump", false);
        }

        if(IsGrounded() )
        {
            doubleJump = false;       
        }




        Flip();
    }

    ///-///////////////////////////////////////////////////////////
    ///
    public void OnMove(CallbackContext InputValues)
    {
        horizontal = InputValues.ReadValue<Vector2>().x;

        animator.SetFloat("Speed", Mathf.Abs(horizontal));
    }

    ///-///////////////////////////////////////////////////////////
    ///
    public void OnJump(CallbackContext InputValues)
    {
        if (IsGrounded() || doubleJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            animator.SetBool("Jump", true);
        }
        else
        {
            if (rb.velocity.y > 0f)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            }
        }
    }
    ///-///////////////////////////////////////////////////////////
    ///
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    ///-///////////////////////////////////////////////////////////
    ///
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    ///-///////////////////////////////////////////////////////////
    ///
    private void Flip() { 
      // Flip our GameObject everyTime we change direction
        if(isFacingRight && horizontal < 0f || isFacingRight == false && horizontal > 0f)
        {
            //Invert Transform of object
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
