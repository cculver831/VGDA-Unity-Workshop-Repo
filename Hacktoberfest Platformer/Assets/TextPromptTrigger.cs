using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextPromptTrigger : MonoBehaviour
{

    public string[] lines;
    public float textSpeed;
    [SerializeField]
    private bool hasTriggered = false;

    public void TriggeredDialog() {
        if(hasTriggered == false)
        {

            UIManager.instance.DisplayDialog(lines, textSpeed);
            hasTriggered = true;
        }
        
    }
}
