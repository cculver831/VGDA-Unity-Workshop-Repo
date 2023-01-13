using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] [Range(5, 100)]
    private float _totalHealth = 25;
    public float totalHealth => _totalHealth;


    ///-///////////////////////////////////////////////////////////
    ///
    public void ModifyHealth(float damage)
    {
        _totalHealth -= damage;
        if (totalHealth <= 0)
        {

            Debug.LogFormat("player dead ;(");
        }
    }
}
