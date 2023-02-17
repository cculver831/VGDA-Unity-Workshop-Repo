using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public override void ModifyHealth(float damage)
    {
        base.ModifyHealth(damage);

        if (totalHealth >= base.maxHealth)
        {
            
        }

        //if our health is to low, we die
        if (totalHealth <= 0)
        {
    
            //CHALLENGE: Add a death animation to play here

            //restart the game
            TransitionManager.Instance.SetEndLevel(0);
            
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
        CinemachineShake.Instance.Shakecamera();

        return base.Hurting();

    }
}
