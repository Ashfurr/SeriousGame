using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uiScript : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera firstCam;
    [SerializeField] CinemachineVirtualCamera secondCam;
    [SerializeField] CinemachineVirtualCamera thirdCam;

    void gardenView()
    {
        firstCam.enabled = false;
        secondCam.enabled = true;
        thirdCam.enabled = false;
    }
    void receptionView()
    {
        firstCam.enabled = true;
        secondCam.enabled = false;
        thirdCam.enabled = false;
    }
    void cookView()
    {
        firstCam.enabled = false;
        secondCam.enabled = false;
        thirdCam.enabled = true;
    }


}
