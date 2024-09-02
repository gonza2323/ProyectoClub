using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.PackageManager.Requests;
using UnityEngine;

public class Engine : MonoBehaviour
{
    public enum EngineStatus {
        OFF,
        RUNNING,
        NO_FUEL,
    }

    public float fuelConsumptionPerSecond = 10f;
    public float thrust = 10.0f;
    public EngineStatus engineStatus = EngineStatus.OFF;
    public FuelSystem fuelSystem;
    public Rigidbody rigidBody;

    // temporal
    public FuelTank fuelTank;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        fuelSystem = new FuelSystem();
        fuelSystem.addFuelTank(fuelTank);
    }

    void Update()
    {
        switch (engineStatus)
        {
            case EngineStatus.OFF:
                if (UnityEngine.Input.GetKeyDown(KeyCode.Space))
                    engineStatus = EngineStatus.RUNNING;
                break;

            case EngineStatus.RUNNING:
                float requiredFuel = fuelConsumptionPerSecond * Time.deltaTime;
                float availableFuel = requestFuel(requiredFuel);
                
                if (availableFuel > 0.0f)
                {
                    Vector3 forceDirection = Vector3.forward;
                    float forceMagnitude = thrust * (availableFuel / requiredFuel);
                    rigidBody.AddRelativeForce(forceDirection * forceMagnitude, ForceMode.Impulse);
                } else {
                    engineStatus = EngineStatus.NO_FUEL;
                    break;
                }

                if (UnityEngine.Input.GetKeyDown(KeyCode.Space))
                    engineStatus = EngineStatus.OFF;
                break;

            case EngineStatus.NO_FUEL:
                if (UnityEngine.Input.GetKeyDown(KeyCode.Space))
                    engineStatus = EngineStatus.RUNNING;
                break;
        }
    }

    private float requestFuel(float quantity)
    {
        if (fuelSystem == null)
            return 0.0f;
        
        return fuelSystem.requestFuel(quantity);
    }
}
