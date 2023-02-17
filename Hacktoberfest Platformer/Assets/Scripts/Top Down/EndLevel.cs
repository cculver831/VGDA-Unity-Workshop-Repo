using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public enum Scenes
{
    DUNGEON = 0,
    LEVEL1 = 1,
    LEVEL2 = 2,
    LEVEL3 = 3,
}
public class EndLevel : MonoBehaviour
{
    [Tooltip("Edit the enum values to reflect  build scene index ")]
    public Scenes scene;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            TransitionManager.Instance.SetEndLevel((int) scene);
            
        }
    }
}
