using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public enum Scenes
{
    LEVEL1 = 0,
    LEVEL2 = 1,
    LEVEL3 = 2,
}
public class EndLevel : MonoBehaviour
{

    public Scenes scene;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SceneTransition.Instance.StartSceneTransition((int)scene);

        Debug.LogFormat("sending level info");
    }
}
