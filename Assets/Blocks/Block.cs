using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public FixedJoint fixedJoint;

    // Start is called before the first frame update
    void Awake()
    {
        fixedJoint = GetComponent<FixedJoint>();
        if (!fixedJoint)
            fixedJoint = gameObject.AddComponent<FixedJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
