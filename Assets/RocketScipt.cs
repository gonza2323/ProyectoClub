using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class RocketScipt : MonoBehaviour
{
    public float force = 10;
    private Rigidbody rb;
    public int SpaceisPressed = 0;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpaceisPressed = 1;
        }
        else
        {
            SpaceisPressed = 0;
        }
        while (SpaceisPressed == 1)
        {
            Vector3 forceDirection = Vector3.up;
            rb.AddForce(forceDirection * force, ForceMode.Impulse);
            while (!(Input.GetKeyUp(KeyCode.Space)))
            {
                Thread.Sleep(10);
            }
        }
    }
}