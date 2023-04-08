using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinemachineShake : MonoBehaviour
{
    private CinemachineImpulseSource vCam;

    ///-///////////////////////////////////////////////////////////
    ///
    private void Awake()
    {

        vCam = GetComponent<CinemachineImpulseSource>();
    }

    ///-///////////////////////////////////////////////////////////
    ///
    public void Shakecamera()
    {
        vCam.GenerateImpulse();
    }

}
