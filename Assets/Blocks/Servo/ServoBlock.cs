using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServoBlock : MonoBehaviour
{
    public KeyCode PositiveRotation;
    public KeyCode NegativeRotation;

    public float RotationSpeed;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(PositiveRotation))
        {
            RotatePositive(RotationSpeed);
        }

        if (Input.GetKey(NegativeRotation))
        {
            RotateNegative(RotationSpeed);
        }
    }

    public void RotatePositive(float rotationSpeed)
    {
        transform.Rotate(0, rotationSpeed, 0);
    }

    public void RotateNegative(float rotationSpeed)
    {
        transform.Rotate(0, -rotationSpeed, 0);
    }
}
