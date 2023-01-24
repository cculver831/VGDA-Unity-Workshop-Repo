using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public enum Scenes
{
    START = 0,
    LEVEL1 = 1,
    LEVEL2 = 2,
    LEVEL3 = 3,
}
public class EndLevel : MonoBehaviour
{

    public Scenes scene;
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.tag == "Player")
        {
            TransitionManager.Instance.SetEndLevel((int) scene);
            
        }
    }
}
