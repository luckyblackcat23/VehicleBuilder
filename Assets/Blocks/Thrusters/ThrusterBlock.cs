using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrusterBlock : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 1;
    public KeyCode ActivateInput;

    // Start is called before the first frame update
    void Start()
    {
        rb = transform.parent.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(ActivateInput))
            rb.AddForceAtPosition(transform.forward * speed, transform.position);
    }
}
