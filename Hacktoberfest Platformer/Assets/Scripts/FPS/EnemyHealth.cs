using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{
    public int health;



    // Update is called once per frame
    void Update()
    {
        
    }

    public override void ModifyHealth(float value)
    {
        base.ModifyHealth(value);
    }

    public void ModifyHP(int damage)
    {
        health += damage;

        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
