using System.Collections;
using System.Collections.Generic;
using System.Net.Mail;
using UnityEngine;

public class Part : MonoBehaviour
{
    public string partName;
    List<PartJoint> joints;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


public class PartJoint {
    public Vector3 pos;
    public bool fuelCanGoThrough;
}
