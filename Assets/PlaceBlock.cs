using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceBlock : MonoBehaviour
{
    public GameObject initialPrefab;
    public static GameObject PlacingPrefab;
    public GameObject placingPrefab;
    public static GameObject Vehicle;
    public int currentConnectionPoint;

    public static PlaceBlock place;

    private void Start()
    {
        placingPrefab = initialPrefab;
        place = this;
        UnableToPlacePreviewMaterial = unableToPlacePreviewMaterial;
        PreviewMaterial = previewMaterial;
        PlacingPrefab = placingPrefab;
        InitializePlacing();
    }

    GameObject placing;
    public static RaycastHit hit;
    GameObject AnchorPoint;
    void FixedUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        placing.layer = 2;
        if (!Physics.Raycast(ray, out hit, 100))
        {
            placing.SetActive(false);
        }
    }

    private void Update()
    {
        if(PlacingPrefab != placingPrefab)
        {
            Destroy(placing);
            InitializePlacing();
        }

        Connectable plcCon = placing.GetComponent<Connectable>();
        currentConnectionPoint = (int)Mathf.Repeat(currentConnectionPoint, (int)plcCon.ConnectionPoint?.Count);
        if (hit.transform)
        {
            Connectable con = hit.collider.gameObject.GetComponent<Connectable>();
            if (con)
            {
                //you'll probably need to clean this up later
                if (!AnchorPoint)
                    AnchorPoint = new GameObject();
                Transform conPoint = con.NearestConnectionPoint(hit.point);

                placing.transform.position = conPoint.position;

                AnchorPoint.transform.position = conPoint.position;

                placing.transform.position += conPoint.position - plcCon.ConnectionPoint[currentConnectionPoint].position;

                AnchorPoint.transform.SetParent(Vehicle.transform);
                AnchorPoint.transform.up = plcCon.ConnectionPoint[currentConnectionPoint].TransformDirection(Vector3.up);

                placing.transform.SetParent(AnchorPoint.transform);
                AnchorPoint.transform.up = -conPoint.up;

                placing.transform.SetParent(con.transform.parent);

                placing.SetActive(true);
            }
            else
            {
                placing.SetActive(false);
            }
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            currentConnectionPoint++;
        }

        if (placing.activeSelf)
        {
            if (!PlacingPreview.isColliding)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    GameObject block = Instantiate(PlacingPrefab, placing.transform.position, placing.transform.rotation);
                    block.GetComponent<FixedJoint>().connectedBody = placing.transform.parent.GetComponent<Rigidbody>();
                    block.transform.SetParent(Vehicle.transform);
                }

                placingMeshRend.material = previewMaterial;
            }
            else
            {
                placingMeshRend.material = UnableToPlacePreviewMaterial;
            }
        }
    }

    MeshRenderer placingMeshRend;
    Rigidbody placingRigidBody;
    public Material previewMaterial;
    public static Material PreviewMaterial;
    public Material unableToPlacePreviewMaterial; //peak variable naming
    public static Material UnableToPlacePreviewMaterial;

    public void InitializePlacing()
    {
        placing = Instantiate(PlacingPrefab, Vehicle.transform);

        placing.layer = 2;
        if (!placing.GetComponent<PlacingPreview>())
            placing.AddComponent<PlacingPreview>();

        if (placing.GetComponent<MeshRenderer>())
            placingMeshRend = placing.GetComponent<MeshRenderer>();
        else
            placingMeshRend = placing.GetComponentInChildren<MeshRenderer>();

        if (!PlacingPreview.isColliding)
            placingMeshRend.material = PreviewMaterial;
        else
            placingMeshRend.material = UnableToPlacePreviewMaterial;

        if (!placing.GetComponent<Rigidbody>())
            placingRigidBody = placing.AddComponent<Rigidbody>();
        else
            placingRigidBody = placing.GetComponent<Rigidbody>();
        placingRigidBody.constraints = RigidbodyConstraints.FreezeAll;

        placing.SetActive(false);
        placingPrefab = PlacingPrefab;
    }
}
