using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : MonoBehaviour
{
    [TagSelector]
    public string TagFilter = "";

    [Range(0, 50)] [SerializeField]
    public float knockBackForce = 15;

    [SerializeField]
    [Range(0, 20)]
    private float damageDealt = 2f;
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == TagFilter)
        {
            //Modify Health
            collision.gameObject.GetComponent<Health>().ModifyHealth(damageDealt);


            //Apply knockback
            Vector2 direction = (collision.transform.position - transform.position);
            direction.Normalize();
           // collision.gameObject.GetComponent<Rigidbody2D>().AddForce(direction * knockBackForce, ForceMode2D.Impulse);
        }
    }

}
