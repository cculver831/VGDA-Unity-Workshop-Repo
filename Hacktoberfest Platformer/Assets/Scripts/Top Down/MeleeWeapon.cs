using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MeleeWeapon : MonoBehaviour
{
    [TagSelector]
    public string TagFilter = "";

    [Range(0, 50)] [SerializeField]
    public float knockBackForce = 15;

    [SerializeField]
    [Range(0, 20)]
    private float damageDealt = 2f;

    [SerializeField]
    private AudioSource audio;
    ///-///////////////////////////////////////////////////////////
    ///
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.transform.tag == TagFilter)
        {
            if(collision.collider.transform.tag == "Player")
                Debug.LogFormat("player hit {0}", damageDealt);


            //Modify Health
            Health health = collision.gameObject.GetComponent<Health>();

            if(health.IsHurt == false)
            {
                if(audio)
                    audio.Play();

                health.ModifyHealth(-damageDealt);


                //Apply knockback
                Vector2 direction = (collision.transform.position - transform.position);

                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(direction * knockBackForce, ForceMode2D.Impulse);
            }
            
        }
    }

}
