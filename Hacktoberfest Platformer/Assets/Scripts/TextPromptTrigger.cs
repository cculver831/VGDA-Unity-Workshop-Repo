using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextPromptTrigger : MonoBehaviour
{
    [TagSelector]
    public string tagFilter = "";
    public string[] lines;
    public float textSpeed;
    [SerializeField]
    private bool hasTriggered = false;


    ///-///////////////////////////////////////////////////////////
    ///
    public void TriggeredDialog() {
        if(hasTriggered == false)
        {

            UIManager.instance.DisplayDialog(lines, textSpeed);
            hasTriggered = true;
        }
        
    }

    ///-///////////////////////////////////////////////////////////
    ///
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (hasTriggered == false && collision.tag == tagFilter)
        {
            UIManager.instance.DisplayDialog(lines, textSpeed);
            hasTriggered = true;
        }
    }
}
