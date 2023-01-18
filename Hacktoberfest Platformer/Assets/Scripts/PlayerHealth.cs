using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : Health
{

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

        if (totalHealth <= 0)
        {
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
