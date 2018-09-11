﻿
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowMinimap : MonoBehaviour
{
    public Transform target;            // The position that that camera will be following.
    public float smoothing = 5f;        // The speed with which the camera will be following.

    private Vector3 offset;                     // The initial offset from the target.

   
    private void Start()
    {
        // Calcate the initial offset.ul
        offset = transform.position - target.position;
      
    }

    private void FixedUpdate()
    {
        
         Vector3 targetCamPos = target.position + offset;

        // Smoothly interpolate between the camera's current position and it's target position.
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
    }


}



