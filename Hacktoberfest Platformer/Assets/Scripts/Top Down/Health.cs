using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] [Range(5, 100)]
    private float _totalHealth = 25;
    public float totalHealth => _totalHealth;

    public bool IsHurt { get; private set; } = false;
    ///-///////////////////////////////////////////////////////////
    ///
    public void ModifyHealth(float damage)
    {
        StartCoroutine(Hurting());
        _totalHealth -= damage;
        if (totalHealth <= 0)
        {

            Debug.LogFormat("player dead ;(");
        }
    }

    IEnumerator Hurting()
    {
        IsHurt = true;
        yield return new WaitForSeconds(0.5f);
        IsHurt = false;
    }
}
