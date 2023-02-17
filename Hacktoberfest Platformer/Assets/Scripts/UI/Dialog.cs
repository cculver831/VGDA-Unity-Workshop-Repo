using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

// Link to tutorial for dialog system: https://www.youtube.com/watch?v=8oTYabhj248
public class Dialog : MonoBehaviour
{

    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    private int index;
    private bool isDialogPlaying = false;

    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
    }

    ///-///////////////////////////////////////////////////////////
    ///
    public void StartDialog(string[] textToDisplay)
    {
        if (isDialogPlaying) { return; }
        textComponent.text = string.Empty;

        Debug.LogFormat("dialog received");

        //CHALLENGE: cloning the string is a bit unnecessary, find a way to copy the string
        lines = (string[])textToDisplay.Clone();
        index = 0;
        StartCoroutine(TypeLine(lines));
    }



    ///-///////////////////////////////////////////////////////////
    ///
    public void OnReadDialog(CallbackContext inputValue)
    {
        
        //Debug.LogFormat("input value {0}", inputValue.performed);
        if (inputValue.performed)
        {
            if (textComponent.text == lines[index] && inputValue.performed)
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
       
    }

    ///-///////////////////////////////////////////////////////////
    ///
    IEnumerator TypeLine(string[] lines)
    {
        isDialogPlaying = true;
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }


    ///-///////////////////////////////////////////////////////////
    ///
    public void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine(lines));
        }
        else
        {
           
            gameObject.SetActive(false);
            isDialogPlaying = false;
        }
    }
}
