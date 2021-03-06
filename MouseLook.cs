﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float sensivity;
    float otherRotation = 0f;
    public Transform playerBody;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X")*sensivity*Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y")*sensivity*Time.deltaTime;
        otherRotation -= mouseY;
        otherRotation = Mathf.Clamp(otherRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(otherRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
    
}
