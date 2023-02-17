using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextPromptTrigger : MonoBehaviour
{
    public string[] lines;
    public float textSpeed;


    ///-///////////////////////////////////////////////////////////
    ///
    public void TriggeredDialog() {
   
            UIManager.instance.DisplayDialog(lines, textSpeed);

    }

}
