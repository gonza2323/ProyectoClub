using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelTankScript : MonoBehaviour
{
    public float maxFuelCapacity = 1000;
    public float fuelQuantity;
    // Start is called before the first frame update
    void Start()
    {
        fuelQuantity = maxFuelCapacity;
    }
}
