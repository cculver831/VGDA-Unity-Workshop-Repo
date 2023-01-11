using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Range(0, 20)]
    public float LOS;

    Rigidbody2D player;

    [SerializeField]
    Rigidbody2D rb;
    [SerializeField]
    Animator animator;

    private bool isFacingRight = true;

    private bool isMoving = false;
    // minimum displacement to recognize a 
    Vector3 lastPos;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Vector3.Distance(transform.position,player.position) <= LOS)
        {
            //Get direction of player
            Vector2 direction = (player.position - rb.position);
            direction.Normalize();

            //Move towards direction
            rb.MovePosition(rb.position + direction * 3 * Time.fixedDeltaTime);
            isMoving = true;

            //Flip direction as needed
            Flip(direction.x);
        }
        else
        {
            isMoving = false;
        }
        

    }
    ///-///////////////////////////////////////////////////////////
    ///
    private void Update()
    {
        UpdateMovementAnimation();


    }

    ///-///////////////////////////////////////////////////////////
    ///
    private void Flip(float xValue)
    {
        // Flip our GameObject everyTime we change direction
        if (isFacingRight && xValue < 0f || isFacingRight == false && xValue > 0f)
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



        Vector2 offset = transform.position - lastPos;

        if (isMoving)
        {
            animator.SetBool("isRunning", true);
            lastPos = transform.position;
        }
        else
        {
            animator.SetBool("isRunning", false);
        }

    }
}
