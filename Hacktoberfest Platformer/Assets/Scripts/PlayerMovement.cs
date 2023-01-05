using UnityEngine;


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
        horizontal = Input.GetAxisRaw("Horizontal");

        animator.SetFloat("Speed" ,Mathf.Abs(horizontal));

        if (IsGrounded())
        {
            animator.SetBool("Jump", false);
        }

        if(IsGrounded() && Input.GetKey(KeyCode.Space) == false)
        {
            doubleJump = false;       
        } 

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (IsGrounded() || doubleJump)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
                doubleJump = !doubleJump;
                animator.SetBool("Jump", true);
            }

        }

        if(Input.GetKeyUp(KeyCode.Space) && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        Flip();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }


    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

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
