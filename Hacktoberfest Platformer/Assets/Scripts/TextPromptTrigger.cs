using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextPromptTrigger : MonoBehaviour
{
    [TagSelector]
    public string tagFilter = "";
    public string[] lines;
    public float textSpeed;


    ///-///////////////////////////////////////////////////////////
    ///
    public void TriggeredDialog() {
   
            UIManager.instance.DisplayDialog(lines, textSpeed);

    }

}
