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
    protected Animator animator;
    public bool IsHurt { get; private set; } = false;

    protected void Start()
    {
        animator = GetComponent<Animator>();
    }


    ///-///////////////////////////////////////////////////////////
    ///
    public virtual void ModifyHealth(float value)
    {

        Debug.LogFormat("getting hurt");
        _totalHealth += value;

        if (value < 0 && IsHurt == false)
        {
           
            StartCoroutine(Hurting());
        }

       

        if (totalHealth <= 0)
        {
            //animator.Play("Death");
            //TODO: Remove and add to inherited EnemyHealth class
            if(room)
                room.CheckCount();
            gameObject.SetActive(false);

        }
    }

    ///-///////////////////////////////////////////////////////////
    ///
    public virtual IEnumerator Hurting()
    {
        
        IsHurt = true;
        yield return new WaitForSecondsRealtime(0.5f);
        
        IsHurt = false;
    }


}
