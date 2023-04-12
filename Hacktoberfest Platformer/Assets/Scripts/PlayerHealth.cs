using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class PlayerHealth : Health
{

    //CHALLENGE hook up slider to player health
    public Slider slider;

    ///-///////////////////////////////////////////////////////////
    ///
    void Start()
    {
        maxHealth = totalHealth;
        SetMaxHealth(maxHealth);
    }


    ///-///////////////////////////////////////////////////////////
    ///
    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    ///-///////////////////////////////////////////////////////////
    ///
    [PunRPC]
    public override void ModifyHealth(float damage)
    {
        base.ModifyHealth(damage);


        //if our health is to low, we die
        if (totalHealth <= 0)
        {
    
            //CHALLENGE: Add a death animation to play here

            //restart the game

            
        }

        SetHealthBar(totalHealth);
    }

    ///-///////////////////////////////////////////////////////////
    ///
    public void SetHealthBar(float health)
    {
        slider.value = health;
    }

    ///-///////////////////////////////////////////////////////////
    ///
    public override IEnumerator Hurting()
    {
        //Shake screen when hurt
        photonView.GetComponent<TopDownMovement>().cameraShake.Shakecamera();

        return base.Hurting();

    }

    [PunRPC]
    public override void Die()
    {
       
        //Leaving blank for playtesting
        
    }
}
