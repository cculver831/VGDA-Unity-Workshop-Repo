using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBoost : MonoBehaviour
{
    [Range(1, 100)]
    public int Health;

    ///-///////////////////////////////////////////////////////////
    ///
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Health health = collision.gameObject.GetComponent<Health>();
        if (health != null)
        {
            health.ModifyHealth(Health);

            //destroy bottle
            Destroy(gameObject);
        }
    }


}
