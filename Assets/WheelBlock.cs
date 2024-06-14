using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelBlock : MonoBehaviour
{
    public KeyCode Drive = KeyCode.W;
    public KeyCode Reverse = KeyCode.S;
    public float MotorTorque = 10;
    public Transform Direction;

    public Rigidbody rb;

    private void Update()
    {

    }

    RaycastHit hit;
    private void FixedUpdate()
    {
        if (!GameManager.buildMode)
        {
            if (Physics.Raycast(transform.position, -Direction.up, out hit, 2))
            {
                if (Input.GetKey(Drive))
                    rb.AddForceAtPosition(transform.forward * MotorTorque, transform.position - (transform.position - hit.point));
            }
        }
    }
}
