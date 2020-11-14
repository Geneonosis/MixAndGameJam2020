﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookAt : MonoBehaviour
{
    public Transform target;

    void Update()
    {
        // Rotate the camera every frame so it keeps looking at the target
        //transform.LookAt(target);
        Vector3 newPos = new Vector3(target.transform.position.x, this.transform.position.y, target.position.z);
        this.transform.position = newPos;
    }
}
