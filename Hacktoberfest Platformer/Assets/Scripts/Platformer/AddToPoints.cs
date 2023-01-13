using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddToPoints : MonoBehaviour
{

    public SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
       // EventSystemExample.instance.onEventSystemNeededEnter += DebugOutput;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DebugOutput()
    {
        Debug.LogWarning("Event System Called... changing colors..");
        sprite.color = Color.green;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {

        Debug.LogFormat("colliding with: {0}", collision.name);
        if(collision.gameObject.tag == "Player")
        {
            UIManager.instance.AddPoints();
            Destroy(gameObject);
        }
        
    }
}
