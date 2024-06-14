using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterRay : MonoBehaviour
{
    public KeyCode Fire;
    public float Recoil;

    [HideInInspector]
    public Rigidbody rb;

    RaycastHit hit;
    // Update is called once per frame
    void Update()
    {
        Physics.Raycast(transform.position, -transform.forward, out hit, 100);

        if (Input.GetKeyDown(Fire))
        {

            //muzzle flare or something here
            /*
            Hittable hittable = hit.collider.gameObject.GetComponent<Hittable>();
            if (hittable)
            {
                hittable.Health--;
            }
            */

            rb.AddForceAtPosition(-transform.forward * Recoil, transform.position);
        }
    }
}
