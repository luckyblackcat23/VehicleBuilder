using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connectable : MonoBehaviour
{
    //when you exit build mode remove this component
    
    public List<Transform> ConnectionPoint;
    
    public Transform NearestConnectionPoint(Vector3 Position)
    {
        Transform nearest = null;

        foreach (Transform connectionPoint in ConnectionPoint)
        {
            if(nearest)
            {
                if (Vector3.Distance(Position, connectionPoint.position) < Vector3.Distance(Position, nearest.position))
                {
                    nearest = connectionPoint;
                }
            }
            else
            {
                nearest = connectionPoint;
            }
        }
        
        return nearest;
    }
}
