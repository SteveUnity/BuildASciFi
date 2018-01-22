using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BuildingData", menuName = "Building/BuildingUnit", order = 2)]
public  class BuildingUnit : ScriptableObject {

    public new string name;
    public GameObject[] models;

    public float maxHealth;
    public int maxWorkersCount;
    /// <summary>
    /// if the building requires a manager to run (manager not included in maxWorkersCount)
    /// </summary>
    public bool requiresManager;
    public float constructionTime;
    /// <summary>
    /// the width and debth of the building (space required to build this unit)
    /// </summary>
    public Vector2Int buildingSize;
    /// <summary>
    /// resources required per second to keep the structure running
    /// </summary>
    public Resources resourcesConsumption;
    public Resources buildingCosts;
    public SpecialProperty[] properties;
    
    [System.Serializable]
    public struct SpecialProperty
    {
        public string property;
        public float value;
    }

    public GameObject CreateInst (){
        return Instantiate(models[0]);
    }

    

}
