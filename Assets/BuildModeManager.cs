using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildModeManager : MonoBehaviour
{
    public static VehicleManager CurrentVehicle; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void ExitBuildMode()
    {
        Rigidbody rb = CurrentVehicle.gameObject.AddComponent<Rigidbody>();
        //replace build mode camera with another one
        PlaceBlock.place.enabled = false;
        GameManager.buildMode = false;
    }

    public static void EnterBuildMode()
    {
        GameManager.buildMode = true;
    }

    public static void ChangeCurrentlyPlacing(GameObject placing)
    {
        PlaceBlock.PlacingPrefab = placing;
    }
}
