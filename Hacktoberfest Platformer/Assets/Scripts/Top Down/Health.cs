using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] [Range(5, 100)]
    private float _totalHealth = 25;
    public float totalHealth => _totalHealth;

    [SerializeField]
    public RoomManager room;

    [SerializeField]
    Animation deathAnimation;
    public bool IsHurt { get; private set; } = false;
    ///-///////////////////////////////////////////////////////////
    ///
    public virtual void ModifyHealth(float value)
    {
        if(value < 0)
        {
            StartCoroutine(Hurting());
        }

        _totalHealth += value;

        if (totalHealth <= 0)
        {
            //TODO: Remove and add to inherited EnemyHealth class
            if(room)
                room.CheckCount();
            gameObject.SetActive(false);

        }
    }

    public virtual IEnumerator Hurting()
    {
        IsHurt = true;
        yield return new WaitForSeconds(0.5f);
        IsHurt = false;
    }
}
