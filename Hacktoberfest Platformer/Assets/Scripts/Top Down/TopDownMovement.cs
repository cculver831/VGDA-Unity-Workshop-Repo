using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class TopDownMovement : MonoBehaviourPun
{
    
    public Vector2 movementInput {get; private set;}
    Vector2 rotationInput;
    public Rigidbody2D rb { get; private set; }
    [SerializeField]
    private Animator playerAnimator;
    [SerializeField]
    private Animator attackAnimator;
    [SerializeField]
    private PlayerInput playerInput;
    [SerializeField]
    private SpriteRenderer sr;
    private PhotonView pv;
    public float moveSpeed = 1f;
    [SerializeField]
    Transform weapon;
    [Range(0,1)]
    public float collisionOffset = 0.05f;

    [Header("Network Objects")]
    public GameObject playerCamera;
    public CinemachineShake cameraShake;
    public UIManager PlayerUI;
    public TextMeshProUGUI playerName;
    public ContactFilter2D movementFilter;

    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();


    ///-///////////////////////////////////////////////////////////
    ///
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pv = GetComponentInParent<PhotonView>();

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

        Flip();
       
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

            // Rotate towards w/ stick movement
            float zRotation = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            weapon.rotation = Quaternion.Euler(0f, 0f, zRotation);

        }


    }

    
    ///-///////////////////////////////////////////////////////////
    /// TODO: make RPC
    public void Flip()
    {
        //Flip sprite based on player x input
        if (movementInput.x > 0f && sr.flipX == true) 
        { 
            sr.flipX = false;
            pv.RPC("NetworkFlip", RpcTarget.OthersBuffered, false);
        }
        else if(movementInput.x < 0f && sr.flipX == false)
        {
            sr.flipX = true;
            pv.RPC("NetworkFlip", RpcTarget.OthersBuffered, true);
        }


        
    }

    [PunRPC]
    public void NetworkFlip(bool val)
    {
        sr.flipX = val;
    }

    [PunRPC]
    public void SetPlayerName(int id)
    {
        PhotonView view = PhotonView.Find(id);
        playerName.text = view.Owner.NickName;
        playerName.enabled = true;
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

    //CHALLENGE: Add controller callback for any button

    ///-///////////////////////////////////////////////////////////
    ///
    public void OnLook(CallbackContext inputValue)
    {
        //Vector2 playerOffSet = new Vector2()

        if (inputValue.ReadValue<Vector2>() != Vector2.zero)
        {

            // If the current input is a mouse
            if (inputValue.control.displayName == "Delta")
            {
                // Find the position of the mouse on the screen
                Vector3 mousePos = Mouse.current.position.ReadValue();

                // Convert that mouse position to a coordinate in world space
                Vector3 Worldpos = playerCamera.GetComponent<Camera>().ScreenToWorldPoint(mousePos);

                rotationInput = Worldpos - transform.position;


            }
            // If the current input is a gamepad
            else if (inputValue.control.displayName == "Right Stick")
            {
                // Read rotationInput straight from the joystick movement
                rotationInput = inputValue.ReadValue<Vector2>();

            }
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
