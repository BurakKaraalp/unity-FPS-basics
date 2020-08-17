using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public CharacterController controller;
    public float Speed = 10f;

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 move = transform.right * horizontal + transform.forward * vertical;
        controller.Move(move*Speed*Time.deltaTime);

    }
}
