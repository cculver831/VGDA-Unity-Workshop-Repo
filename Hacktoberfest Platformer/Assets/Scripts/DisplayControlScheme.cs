using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class DisplayControlScheme : MonoBehaviour
{
    public GameObject keyboardControls;
    public GameObject gamepadControls;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnChangeInput(PlayerInput pl)
    {
       if(pl!= null && pl.currentControlScheme.Equals("Gamepad"))
        {
            keyboardControls.SetActive(false);
            gamepadControls.SetActive(true);
        }
        else
        {
            keyboardControls.SetActive(true);
            gamepadControls.SetActive(false);
        }
    }
}
