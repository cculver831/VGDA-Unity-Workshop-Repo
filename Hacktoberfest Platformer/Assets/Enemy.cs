using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Range(0, 20)]
    public float LOS;
    [Range(0f, 5f)]
    public float attackDistance;
    Rigidbody2D player;

    [SerializeField]
    Rigidbody2D rb;
    [SerializeField]
    Animator characterAnimator;
    [SerializeField]
    Animator weaponAnimator;
    [SerializeField]
    Transform weapon;

    [SerializeField]
    Health Health;
    private bool isMoving = false;
    private float prevHaelth;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        prevHaelth = Health.totalHealth;
    }


    ///-///////////////////////////////////////////////////////////
    ///
    private void Update()
    {
        UpdateMovementAnimation();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 direction = (player.position - rb.position);
        direction.Normalize();

        WeaponFollow(direction);

        LineOfSight(direction);
      

       
  
    }

    ///-///////////////////////////////////////////////////////////
    ///
    void LineOfSight(Vector2 direction)
    {
        if (Vector3.Distance(transform.position, player.position) <= LOS && Health.IsHurt == false)
        {
            if (Vector3.Distance(transform.position, player.position) < attackDistance)
            {

                StartCoroutine(Attack());

                isMoving = false;
            }
            else
            {
                //Move towards direction
                rb.MovePosition(rb.position + direction * 3 * Time.fixedDeltaTime);
                isMoving = true;

                Flip(direction, GetComponent<SpriteRenderer>()); ;
            }

        }
        else
        {
            isMoving = false;
        }
    }

    ///-///////////////////////////////////////////////////////////
    ///
    void WeaponFollow(Vector2 direction)
    {

        //Move weapon within radius around enemy
        Vector2 v = player.position - rb.position;
        v = Vector2.ClampMagnitude(v, 1f);
        Vector2 newLocation = rb.position + v;
        weapon.transform.position = Vector2.MoveTowards(weapon.transform.position, newLocation, 1f);


        //Look at player
        float zRotation = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        weapon.gameObject.transform.rotation = Quaternion.Euler(0f, 0f, zRotation);
    }

    ///-///////////////////////////////////////////////////////////
    ///
    IEnumerator Attack()
    {

        yield return new WaitForSeconds(1f);

        weaponAnimator.SetBool("isAttacking", true);
    }



    ///-///////////////////////////////////////////////////////////
    ///
    private void Flip(Vector2 input, SpriteRenderer sr)
    {

        if (input.x > 0f)
        {
            sr.flipX = false;
        }
        else if (input.x < 0f)
        {
            sr.flipX = true;
        }
    }


    ///-///////////////////////////////////////////////////////////
    ///
    void UpdateMovementAnimation()
    {
        if (isMoving)
        {
            characterAnimator.SetBool("isRunning", true);

        }
        else
        {
            characterAnimator.SetBool("isRunning", false);
        }

    }
}
