using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HingeBlock : MonoBehaviour
{
    public GameObject Centre;

    public KeyCode PositiveRotation;
    public KeyCode NegativeRotation;

    public float RotationSpeed;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(PositiveRotation))
        {
            Centre.transform.Rotate(0, 0, RotationSpeed);
        }
        if (Input.GetKey(NegativeRotation))
        {
            Centre.transform.Rotate(0, 0, -RotationSpeed);
        }
        Centre.transform.localRotation = Quaternion.Euler(0, 0, Mathf.Clamp(Centre.transform.localRotation.eulerAngles.z, -90, 90));
    }
}
