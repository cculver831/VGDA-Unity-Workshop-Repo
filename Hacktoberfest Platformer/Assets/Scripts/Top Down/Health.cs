using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Health : MonoBehaviourPun
{
    [SerializeField] [Range(5, 100)]
    private float _totalHealth = 25;
    public float totalHealth => _totalHealth;

    public float maxHealth { get; protected set; }
    [SerializeField]
    public RoomManager room;

    [SerializeField]
    Animator deathAnimation;

    public bool IsHurt { get; protected set; } = false;

    private void Start()
    {
        maxHealth = _totalHealth;
        deathAnimation = GetComponent<Animator>();
        //Debug.LogFormat("setting max health {0}", maxHealth);
    }

    [PunRPC]
    ///-///////////////////////////////////////////////////////////
    ///
    public virtual void ModifyHealth(float value)
    {

        if (IsHurt == false)
        {
            if (value < 0)
            {
                if(deathAnimation)
                    deathAnimation.SetTrigger("Hurt");
            }

            _totalHealth += value;


            if (totalHealth <= 0)
            {
                
                //TODO: Remove and add to inherited EnemyHealth class
                if (room)
                    room.CheckCount();
                photonView.RPC("Die", RpcTarget.AllBufferedViaServer);

            }
        }
       
    }

    ///-///////////////////////////////////////////////////////////
    ///
    public virtual IEnumerator Hurting()
    {
        yield return new WaitForSeconds(0.5f);
  
    }

    [PunRPC]
    public void Die()
    {

        Debug.LogFormat("{0} died", gameObject.name);
        photonView.gameObject.SetActive(false);

    }

    public void SetHurt()
    {
        IsHurt = !IsHurt;
    }
}
