using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EngineScript : MonoBehaviour
{
    public enum EngineStatus {
        OFF,
        RUNNING,
        NO_FUEL,
    }

    public float fuelConsumptionPerSecond = 10f;
    public EngineStatus engineStatus = EngineStatus.OFF;
    public List<FuelTankScript> connectedFuelTanks;
    public Rigidbody rigidBody;

    void Update()
    {
        switch (engineStatus)
        {
            case EngineStatus.OFF:
                if (Input.GetKeyDown(KeyCode.Space))
                    engineStatus = EngineStatus.RUNNING;
                break;
            case EngineStatus.RUNNING:
                if (tryGetFuel())
                {
                    Vector3 forceDirection = Vector3.up;
                    rigidBody.AddRelativeForce(forceDirection, ForceMode.Impulse);
                }

                if (Input.GetKeyDown(KeyCode.Space))
                    engineStatus = EngineStatus.OFF;
                break;
        }
    }

    private bool tryGetFuel()
    {
        return true;
    }
}
