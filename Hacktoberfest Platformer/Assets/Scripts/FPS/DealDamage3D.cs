using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage3D : MonoBehaviour
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
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == TagFilter)
        {
            //Modify Health
            Health health = other.gameObject.GetComponent<Health>();
            if (health.IsHurt == false)
            {
                health.ModifyHealth(-damageDealt);

                Debug.LogFormat("hit");

                //Apply knockback
                Vector2 direction = (other.transform.position - transform.position);

                other.gameObject.GetComponent<Rigidbody>().AddForce(direction * knockBackForce, ForceMode.Impulse);
            }

        }
    }



}
