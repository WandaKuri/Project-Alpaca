using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraController : MonoBehaviour
{

    //private CinemachineVirtualCamera myCinemachine;
    public Transform target;
    private Transform bottomLeftBox;
    private Transform topRightBox;
    private Vector3 bottomLeftLimit;
    private Vector3 topRightLimit;

    private float halfHeight;
    private float halfWidth;

    
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;

        halfHeight = Camera.main.orthographicSize;
        halfWidth = halfHeight * Camera.main.aspect;

        //////////myCinemachine = GetComponent<CinemachineVirtualCamera>();
        bottomLeftBox = GameObject.FindGameObjectWithTag("bottomLeft").transform;
        topRightBox = GameObject.FindGameObjectWithTag("topRight").transform;
        bottomLeftLimit = new Vector3(bottomLeftBox.position.x, bottomLeftBox.position.y, bottomLeftBox.position.z) + new Vector3(halfWidth, halfHeight, 0f);
        topRightLimit = new Vector3(topRightBox.position.x, topRightBox.position.y, topRightBox.position.z) + new Vector3(-halfWidth, -halfHeight, 0f);
    }

    private void Awake()
    {
        //////////myCinemachine.Follow = target.transform;
        

    }

    // Update is called once per frame
    void LateUpdate()
    {

        transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
        //////////myCinemachine.Follow = GameObject.FindGameObjectWithTag("Player").transform;
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, bottomLeftLimit.x, topRightLimit.x), Mathf.Clamp(transform.position.y, bottomLeftLimit.y, topRightLimit.y), transform.position.z);

    }
}
