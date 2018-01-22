using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "EnergyGeneratorData", menuName = "Building/EnergyGenerator", order = 2)]
public class EnergyGenerator: BuildingUnit {
    public int energyRate;
    public int capacity;
}
