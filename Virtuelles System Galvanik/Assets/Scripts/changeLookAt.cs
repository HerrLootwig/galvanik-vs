using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class changeLookAt : MonoBehaviour
{

    CinemachineVirtualCamera vcam;

    private void Awake()
    {
        vcam = GetComponent<CinemachineVirtualCamera>();
    }

    public void LookAt(Transform target)
    {
        vcam.m_LookAt = target.transform;
    }
}
