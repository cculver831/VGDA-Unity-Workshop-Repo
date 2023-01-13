using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class Dialog : MonoBehaviour
{

    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    private int index;
    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
        StartDialog();
    }

    ///-///////////////////////////////////////////////////////////
    ///
    public void StartDialog()
    {
        index = 0;
        StartCoroutine(TypeLine());
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
    IEnumerator TypeLine()
    {
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
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}