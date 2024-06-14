using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverBlock : MonoBehaviour
{
    public float Force = 10;

    public Rigidbody rb;

    RaycastHit hit;
    private void FixedUpdate()
    {
        if (!GameManager.buildMode)
        {
            if (Physics.Raycast(transform.position, -transform.up, out hit, 100))
            {
                rb.AddForceAtPosition(transform.up * Force / hit.distance, transform.position - transform.up, ForceMode.Force);
            }
        }
    }
}
