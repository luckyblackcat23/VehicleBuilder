using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public VehicleManager current;
    public static bool buildMode = true;

    // Start is called before the first frame update
    void Awake()
    {
        BuildModeManager.CurrentVehicle = current;
        PlaceBlock.Vehicle = current.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
