using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] [Range(5, 100)]
    private float _totalHealth = 25;
    public float totalHealth => _totalHealth;

    public float maxHealth { get; protected set; }
    [SerializeField]
    public RoomManager room;

    [SerializeField]
    Animation deathAnimation;

    public bool IsHurt { get; private set; } = false;

    private void Start()
    {
        maxHealth = _totalHealth;

        Debug.LogFormat("setting max health {0}", maxHealth);
    }


    ///-///////////////////////////////////////////////////////////
    ///
    public virtual void ModifyHealth(float value)
    {
        if (IsHurt == false)
        {
            if (value < 0)
            {
                StartCoroutine(Hurting());
            }

            _totalHealth += value;



            if (totalHealth <= 0)
            {
                //TODO: Remove and add to inherited EnemyHealth class
                if (room)
                    room.CheckCount();
                gameObject.SetActive(false);

            }
        }
       
    }

    ///-///////////////////////////////////////////////////////////
    ///
    public virtual IEnumerator Hurting()
    {
        IsHurt = true;
        yield return new WaitForSeconds(0.5f);
        IsHurt = false;
    }
}
