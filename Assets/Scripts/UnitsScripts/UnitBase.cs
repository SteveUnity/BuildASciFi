using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CreateAssetMenu(fileName = "BaseUnitData", menuName = "Units/BaseUnit", order = 1)]
public class UnitBase : ScriptableObject {
    public new string name;
    public GameObject model;
    public float MaxHealth;
    public float movingSpeed;
    public int level;
    public SpecialProperty[] properties;
    public Task unitTask;

    /// <summary>
    /// resources required per second to keep the structure running
    /// </summary>
    [System.Serializable]
    public struct Resources
    {
        public int fuel;
        public int energy;
        public int metal;
        public int stone;
    }
    [System.Serializable]
    public struct BuildCost
    {
        public int fuel;
        public int energy;
        public int metal;
        public int stone;
    }
    [System.Serializable]
    public struct SpecialProperty
    {
        public string property;
        public float value;
    }


    public enum Task
    {
        WorkerUnit,
        SolderUnit,
        ManagerUnit,
        BuilderUnit,
        VehicleUnit,
    }
}
