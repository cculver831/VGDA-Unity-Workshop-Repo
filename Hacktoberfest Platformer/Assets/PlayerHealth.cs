using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerHealth : Health
{
    public float currentHealth;

    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = totalHealth;
        SetMaxHealth(currentHealth);
    }

    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public override void ModifyHealth(float damage)
    {
        base.ModifyHealth(damage);
        SetHealth(totalHealth);
    }

    public void SetHealth(float health)
    {

        //
        //Debug.LogFormat("health value set {0} ", health);
        slider.value = health;
    }

}
