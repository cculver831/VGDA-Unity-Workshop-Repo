using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinemachineShake : MonoBehaviour
{

    public static CinemachineShake Instance { get; private set; }
    private CinemachineImpulseSource vCam;

    ///-///////////////////////////////////////////////////////////
    ///
    private void Awake()
    {
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
