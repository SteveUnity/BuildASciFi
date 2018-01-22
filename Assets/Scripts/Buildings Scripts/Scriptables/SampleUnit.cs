using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SampleData", menuName = "Building/Sample", order = 2)]
public class SampleUnit : BuildingUnit
{

    /// <summary>
    /// production generated per second per worker 
    /// </summary>
    public int productionRate;
   
    /// <summary>
    /// maximum capacity to store produced resources locally
    /// the structure will stop working if capacity reached
    /// </summary>
    public int capacity;

   
}
