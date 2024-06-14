using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleManager : MonoBehaviour
{
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.buildMode)
        {
            if (rb)
            {
                Destroy(rb);
                rb = null;
            }

            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.identity, 1 * Time.deltaTime);
        }
        else
        {
            if (!rb)
            {
                gameObject.AddComponent<Rigidbody>();
                rb = GetComponent<Rigidbody>();
                rb.drag = 1;
                InitializeParts();
            }
        }
    }

    public void InitializeParts()
    {
        if (GetComponentsInChildren<HoverBlock>().Length > 0)
        {
            foreach (HoverBlock hoverBlock in GetComponentsInChildren<HoverBlock>())
            {
                hoverBlock.rb = rb;
            }
        }

        if (GetComponentsInChildren<ThrusterBlock>().Length > 0)
        {
            foreach (ThrusterBlock thrusterBlock in GetComponentsInChildren<ThrusterBlock>())
            {
                thrusterBlock.rb = rb;
            }
        }

        if (GetComponentsInChildren<ShooterRay>().Length > 0)
        {
            foreach (ShooterRay shooterRay in GetComponentsInChildren<ShooterRay>())
            {
                shooterRay.rb = rb;
            }
        }
    }
}
