using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class RocketScipt : MonoBehaviour
{
    public float force = 1;
    private Rigidbody rb;
    public bool SpaceisPressed = false;
    public float G = 10;  
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
       if (Input.GetKey(KeyCode.Space))
        {
            SpaceisPressed = true;
        }
       else
        {
            SpaceisPressed = false;
        }

        if (SpaceisPressed)
        {
            Debug.Log("space is pressed");
            Vector3 forceDirection = Vector3.up;
            rb.AddForce(forceDirection * force, ForceMode.Impulse);

        }
        else {
            Debug.Log("space is NOT pressed");
            Vector3 forceDirection = Vector3.down;
            rb.AddForce(forceDirection * G, ForceMode.Impulse);
        }
        SpaceisPressed = false;
    }
}