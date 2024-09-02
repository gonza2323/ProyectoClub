using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragScript : MonoBehaviour
{
    public float AirDrag = 0;
    private Rigidbody rigidbody;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        float forceMagnitude = rigidbody.velocity.magnitude * AirDrag;
        Vector3 forceDirection = -rigidbody.velocity.normalized;
        rigidbody.AddForce(forceMagnitude * forceDirection, ForceMode.Impulse);
    }
}
