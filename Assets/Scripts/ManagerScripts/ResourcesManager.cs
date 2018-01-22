using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ResourcesManager : MonoBehaviour
{
    public Resources resources = new Resources(100,100,100,100);
    public int Capacity = 0;
    [Space(10)]
    public Text txtE;
    public Text txtF;
    public Text txtM;
    public Text txtS;
    [Space(10)]
    public bool Add500Res = false;

    public void LateUpdate()
    {
        if (Add500Res)
        {
            Add500Res = false;
            resources.Energy += 500;
            resources.Fuel += 500;
            resources.Metal += 500;
            resources.Stone += 500;
        }
        txtE.text = resources.Energy.ToString();
        txtF.text = resources.Fuel.ToString();
        txtM.text = resources.Metal.ToString();
        txtS.text = resources.Stone.ToString();

    }

    public void SpendCost(Resources values)
    {
        resources.Energy -= values.Energy;
        resources.Fuel -= values.Fuel;
        resources.Metal -= values.Metal;
        resources.Stone-= values.Stone;
    }
    public bool HasCost(Resources values)
    {
        if (resources.Energy < values.Energy ||
            resources.Fuel < values.Fuel ||
            resources.Metal < values.Metal||
            resources.Stone < values.Stone)
            return false;
        return true;
    }
}

[System.Serializable]
public struct Resources
{
    public int Energy;

    public int Fuel;

    public int Metal;

    public int Stone;

    public int Capacity
    {
        get
        {
            return Energy + Fuel + Metal + Stone;
        }
    }

    public Resources(int energy, int fuel, int metal, int stone)
    {
        Energy = energy;
        Fuel = fuel;
        Metal = metal;
        Stone = stone;
    }

   

    public void Set(int energy = 0, int fuel = 0, int metal = 0, int stone = 0)
    {
        Energy = energy;
        Fuel = fuel;
        Metal = metal;
        Stone = stone;
    }
   
}
