using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using ExitGames.Client.Photon;

public class Enemy : MonoBehaviourPun
{
    [Range(1, 10)]
    public float speed = 3f;
    [Range(0, 20)]
    public float LOS;
    [Range(0f, 5f)]
    public float attackDistance;

    private float meleeRange => attackDistance;
    Rigidbody2D player;

    [SerializeField]
    Rigidbody2D rb;
    [SerializeField]
    Animator characterAnimator;
    [SerializeField]
    Animator weaponAnimator;
    [SerializeField]
    Transform weapon;
    private GameObject[] Players;

    [SerializeField]
    public Health Health;
    private bool isMoving = false;

    // Start is called before the first frame update
    void Start()
    {
       // player = GameObject.Find("Player").GetComponent<Rigidbody2D>();

    }
    private void OnEnable()
    {

        Debug.LogFormat("listening to callback");
        PhotonNetwork.AddCallbackTarget(this);
    }

    private void OnDisable()
    {
        PhotonNetwork.RemoveCallbackTarget(this);
    }

    // If you have multiple custom events, it is recommended to define them in the used class
    public const byte UPDATETARGETIST = 1;


    ///-///////////////////////////////////////////////////////////
    ///
    public void OnEvent(EventData photonEvent)
    {
        byte eventCode = photonEvent.Code;

        Debug.LogFormat("received byte info");
        if (eventCode == UPDATETARGETIST)
        {
           object[] data = (object[])photonEvent.CustomData;

            int photonID = (int)data[0];

            Rigidbody2D playerRB = PhotonView.Find(photonID).GetComponent<Rigidbody2D>();

            Debug.LogFormat("player added");

        }
    }

    ///-///////////////////////////////////////////////////////////
    ///
    private void Update()
    {
        UpdateMovementAnimation();
    }

    public Rigidbody2D FindClosestEnemy()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Player");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }

        //Debug.LogFormat("closest obj {0}", closest.name);
        return closest.GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {

        if (GameObject.FindGameObjectWithTag("Player"))
        {
            player = FindClosestEnemy();
            Vector2 direction = (player.position - rb.position);
            direction.Normalize();



            LineOfSight(direction, player);
        }

  
      
    }

    ///-///////////////////////////////////////////////////////////
    ///
    void LineOfSight(Vector2 direction, Rigidbody2D player)
    {
        if (Vector3.Distance(transform.position, player.position) <= LOS && Health.IsHurt == false)
        {
            if (Vector3.Distance(transform.position, player.position) <= attackDistance)
            {
                if (weapon != null)
                    WeaponFollow(direction);

                StartCoroutine(Attack());

                isMoving = false;
            }
            else
            {
                //Move towards direction
                rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
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
        v = Vector2.ClampMagnitude(v, meleeRange);
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

        if(weapon != null)
        {
            weaponAnimator.SetBool("isAttacking", true);
        }
        else
        {
            characterAnimator.SetBool("isAttacking", true);
        }
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

        if (characterAnimator.parameterCount > 0) { 

            if(isMoving)
            {
                characterAnimator.SetBool("isRunning", true);
            }
            else
            {
                characterAnimator.SetBool("isRunning", false);
            }
        }
            

    }
}
