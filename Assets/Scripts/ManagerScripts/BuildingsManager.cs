using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BuildingsManager : MonoBehaviour {

    public BuildingUnit commandCenterData;
    public BuildingUnit storageData;
    public BuildingUnit mineData;
    public BuildingUnit energyGenData;
    [Space(5)]

    public int Count = 0;

    public Buildings buildings;
        
   

    
    public delegate void GetResources();
    public GetResources getResources;

   

    public void Start()
    {




        //getResources += marketManager.GenerateMoney;
        if (getResources != null)
            StartCoroutine(GetResourcesPerSecond());
        
    }

   

    IEnumerator GetResourcesPerSecond()
    {
        while (true)
        {
            if (getResources != null)
            {
                getResources();
            }
            yield return new WaitForSeconds(5);
        }
    }
    

}
[System.Serializable]
public class Buildings
{
    public List<BuildManager.CommandCenterRunner> CommandCenters = new List<BuildManager.CommandCenterRunner>();
    public List<BuildManager.EnergyGeneratorRunner> EnergyGenerators = new List<BuildManager.EnergyGeneratorRunner>();
    public List<BuildManager.MineRunner> Mines = new List<BuildManager.MineRunner>();
    public List<BuildManager.StorageRunner> Storages = new List<BuildManager.StorageRunner>();

    /*
    public void AddCommandCenter(BuildManager.CommandCenterRunner item)
    {
        CommandCenters.Add(item);
    }*/

}

