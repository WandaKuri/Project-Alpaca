using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    private CinemachineVirtualCamera myCinemachine;
    
    // Start is called before the first frame update
    void Start()
    {
        myCinemachine = GetComponent<CinemachineVirtualCamera>();
    }

    private void Awake()
    {
        myCinemachine.Follow = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
