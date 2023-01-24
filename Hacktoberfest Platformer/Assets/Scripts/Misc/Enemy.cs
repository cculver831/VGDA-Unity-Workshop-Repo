using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.AI;

public class Enemy : MonoBehaviour
{
    [Range(1, 10)]
    public float speed = 3f;
    [Range(0, 20)]
    public float LOS =5f;
    [Range(0f, 5f)]
    public float attackDistance = 2f;

    private float meleeRange => attackDistance;
    Rigidbody player;
    [Tooltip("The layer we can see an object. necessary to stop AI form wall hacks")]
    [SerializeField]
    LayerMask LOSLayer;
    [SerializeField]
    Rigidbody rb;
    [SerializeField]
    Animator characterAnimator;
    [SerializeField]
    UnityEngine.AI.NavMeshAgent agent;

    [SerializeField]
    Transform weapon;


    [SerializeField]
    public Health Health;
    private bool isMoving = false;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Rigidbody>();

    }


    ///-///////////////////////////////////////////////////////////
    ///
    private void Update()
    {
        UpdateMovementAnimation();
        //|| agent.velocity.sqrMagnitude == 0f
        if (!agent.hasPath )
        {

            Debug.LogFormat("I cannot be moved");
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 direction = (player.position - rb.position);
        direction.Normalize();



        LineOfSight(direction);
      
    }

    ///-///////////////////////////////////////////////////////////
    ///
    void LineOfSight(Vector2 direction)
    {

        // Check if we are close enough to view the player and that they are actually visible to our eyes
        Debug.DrawRay(transform.position, player.position);
        if ((Vector3.Distance(transform.position, player.position) <= LOS) && (Physics.Raycast(rb.position, player.position- rb.position, (int)LOS, LOSLayer )))
        {
            agent.SetDestination(player.position);

            if (Vector3.Distance(transform.position, player.position) < attackDistance)
            {

                StartCoroutine(Attack());
                agent.isStopped = true;

                Debug.LogFormat("attacking");
                isMoving = false;
            }
            else
            {

                agent.isStopped = false;
                Debug.LogFormat("agent destination set");
                //Move towards direction
                //rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
                isMoving = true;

               
            }

        }
        else
        {
            isMoving = false;
            agent.isStopped = false;
        }
    }

  
    ///-///////////////////////////////////////////////////////////
    ///
    IEnumerator Attack()
    {
        characterAnimator.SetTrigger("Attacking");

        yield return new WaitForSeconds(1f);


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
