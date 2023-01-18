using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.InputSystem.InputAction;

public class TransitionManager : MonoBehaviour
{

    public static TransitionManager Instance;

    [SerializeField]
    private Animator animator;

    private int nextScene = 0;
    private bool hasCompletedLevel = false;


    private void Awake()
    {
        Instance = this;
    }

    ///-///////////////////////////////////////////////////////////
    ///
    public void PlayEndTransition()
    {
        
            animator.SetTrigger("EndGame");
    }

    ///-///////////////////////////////////////////////////////////
    ///
    public void LoadNewLevel()
    {

        //Debug.LogFormat("loading new scene {0}", nextScene);

        if (hasCompletedLevel)
        {
            SceneManager.LoadScene(nextScene);
        }
    }

    ///-///////////////////////////////////////////////////////////
    ///
    internal void SetEndLevel(int scene)
    {
        hasCompletedLevel = true;
        nextScene = scene;

        PlayEndTransition();
    }

    ///-///////////////////////////////////////////////////////////
    ///
    public void PlayGame(CallbackContext input)
    {
        animator.SetTrigger("StartGame");
    }
}
