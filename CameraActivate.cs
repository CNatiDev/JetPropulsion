using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CameraActivate : MonoBehaviour
{
    public void OffTimeScale()
    {
        CinemachineBrain cinemachineBrain = GetComponent<CinemachineBrain>();
        if (cinemachineBrain != null)
        {
            cinemachineBrain.m_IgnoreTimeScale = true;
        }
    }
    public void OnTimeScale()
    {
        CinemachineBrain cinemachineBrain = GetComponent<CinemachineBrain>();
        if (cinemachineBrain != null)
        {
            cinemachineBrain.m_IgnoreTimeScale = false;
        }
    }

}
