using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinemachineShake : MonoBehaviour
{

    //Singleton reference
    public static CinemachineShake Instance { get; private set; }

    private CinemachineImpulseSource vCam;

    ///-///////////////////////////////////////////////////////////
    ///
    private void Awake()
    {
        //Singleton design pattern 

        Instance = this;

        vCam = GetComponent<CinemachineImpulseSource>();
    }

    ///-///////////////////////////////////////////////////////////
    ///
    public void Shakecamera()
    {
        vCam.GenerateImpulse();
    }

}
