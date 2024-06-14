using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacingPreview : MonoBehaviour
{
    public static bool isColliding;

    BoxCollider collider;

    MeshRenderer meshRenderer;

    private void Start()
    {
        if (GetComponent<MeshRenderer>())
            meshRenderer = GetComponent<MeshRenderer>();
        else
            meshRenderer = GetComponentInChildren<MeshRenderer>();

        collider = GetComponent<BoxCollider>();
    }

    private void FixedUpdate()
    {
        if (Physics.CheckBox(transform.position, (collider.size * 0.9f) / 2, transform.rotation))
        {
            isColliding = true;
            meshRenderer.material = PlaceBlock.UnableToPlacePreviewMaterial;
        }
        else
        {
            isColliding = false;
            meshRenderer.material = PlaceBlock.PreviewMaterial;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, transform.lossyScale);
        Gizmos.DrawWireCube(Vector3.zero, collider.size * 0.9f);
    }
}
