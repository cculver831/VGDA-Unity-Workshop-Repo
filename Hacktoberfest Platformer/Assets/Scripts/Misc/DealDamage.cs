using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Duplicate script lol
public class DealDamage : MonoBehaviourPun
{
    [TagSelector]
    public string TagFilter = "";

    [Range(0, 50)]
    [SerializeField]
    public float knockBackForce = 15;

    [SerializeField]
    [Range(0, 20)]
    private float damageDealt = 2f;

    ///-///////////////////////////////////////////////////////////
    ///
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == TagFilter)
        {
            //Modify Health
            Health health = collision.gameObject.GetComponent<Health>();
            if (health.IsHurt == false)
            {

                photonView.RPC("ModifyHealth", RpcTarget.All, -damageDealt);

                Debug.LogFormat("hit");

                //Apply knockback
                Vector2 direction = (collision.transform.position - transform.position);

                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(direction * knockBackForce, ForceMode2D.Impulse);
            }

        }
    }

}
