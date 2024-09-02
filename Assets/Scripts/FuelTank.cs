using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class FuelTank : MonoBehaviour
{
    public float maxFuelCapacity = 1000;
    public float fuelQuantity = 1000;

    // Start is called before the first frame update
    public float requestFuel(float quantity)
    {
        float availableFuel = Math.Min(quantity, fuelQuantity);
        fuelQuantity -= quantity;
        return availableFuel;
    }

    public float getFuelQuantity() { return fuelQuantity; }
}


public class FuelSystem {
    public List<FuelTank> fuelTanks;

    private float totalFuel;

    public FuelSystem()
    {
        this.fuelTanks = new List<FuelTank>();
        this.totalFuel = 0.0f;
    }

    public float requestFuel(float quantity) {
        float availableFuel = Math.Min(quantity, totalFuel);
        removeFuel(availableFuel);
        return availableFuel;
    }

    private void removeFuel(float quantity) {
        totalFuel -= quantity;
        IEnumerator<FuelTank> tank = fuelTanks.GetEnumerator();
        while (tank.MoveNext() && quantity > 0)
            quantity -= tank.Current.requestFuel(quantity);
    }

    public void addFuelTank(FuelTank tank)
    {
        fuelTanks.Add(tank);
        totalFuel += tank.getFuelQuantity();
    }
}