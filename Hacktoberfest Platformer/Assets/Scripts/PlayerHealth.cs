using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : Health
{
    public float currentHealth;

    public Slider slider;

    ///-///////////////////////////////////////////////////////////
    ///
    void Start()
    {
        currentHealth = totalHealth;
        SetMaxHealth(currentHealth);
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
        if (totalHealth <= 0)
        {
            //restart the game
            TransitionManager.Instance.SetEndLevel(0);
            
        }
        SetHealth(totalHealth);
    }

    ///-///////////////////////////////////////////////////////////
    ///
    public void SetHealth(float health)
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
