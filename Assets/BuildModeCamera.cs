using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildModeCamera : MonoBehaviour
{
    public float moveSpeed = 8;
    public float rotationSpeed = 8;
    public float panSpeed = 13;
    public static BuildModeCamera buildModeCamera;

    // Start is called before the first frame update
    void Start()
    {
        buildModeCamera = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
            transform.position += transform.forward * Time.deltaTime * moveSpeed;
        if (Input.GetKey(KeyCode.A))
            transform.position += -transform.right * Time.deltaTime * moveSpeed;
        if (Input.GetKey(KeyCode.S))
            transform.position += -transform.forward * Time.deltaTime * moveSpeed;
        if (Input.GetKey(KeyCode.D))
            transform.position += transform.right * Time.deltaTime * moveSpeed;
        if (Input.GetKey(KeyCode.Q))
            transform.position += -transform.up * Time.deltaTime * moveSpeed;
        if (Input.GetKey(KeyCode.E))
            transform.position += transform.up * Time.deltaTime * moveSpeed;

        if (Input.GetMouseButton(1))
        {
            Cursor.lockState = CursorLockMode.Locked;
            transform.SetPositionAndRotation(transform.position, Quaternion.Euler(transform.rotation.eulerAngles.x + -Input.GetAxis("Mouse Y") * rotationSpeed, transform.rotation.eulerAngles.y + Input.GetAxis("Mouse X") * rotationSpeed, 0));
        }
        else if (Input.GetMouseButton(2))
        {
            transform.position += (transform.right * -Input.GetAxis("Mouse X") + transform.up * -Input.GetAxis("Mouse Y")) * Time.deltaTime * panSpeed;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
