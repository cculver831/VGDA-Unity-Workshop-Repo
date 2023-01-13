using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage : MonoBehaviour
{
    [TagSelector]
    public string TagFilter = "";

    [SerializeField] [Range(0, 20)]
    private float damageDealt = 2f;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.LogFormat("hit: {0}", collision.gameObject.name);

        if (collision.gameObject.tag == TagFilter)
        {

            collision.gameObject.GetComponent<Health>().ModifyHealth(damageDealt);


            //Knockback object
            Vector2 direction = (collision.transform.position - transform.position);
            direction.Normalize();
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(direction * 3, ForceMode2D.Impulse);
        }
    }
}