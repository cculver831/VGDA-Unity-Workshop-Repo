using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddToPoints : MonoBehaviour
{
    [TagSelector]
    string objectToCollideWith = "";
    public SpriteRenderer sprite;



    public void OnTriggerEnter2D(Collider2D collision)
    {

        //Debug.LogFormat("colliding with: {0}", collision.name);

        if(collision.gameObject.tag == objectToCollideWith)
        {
            UIManager.instance.AddPoints();
            Destroy(gameObject);
        }
        
    }
}
