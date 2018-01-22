using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour
{

    public Button btnCommandCenter;

    public Button btnStorage;
    public Button btnMine;
    public Button btnEnergyGen;
    [Space(5)]

    AreaSelection area;
    Transform targetT;
    int rot = 0;
    bool buildingPlaced = true;

    void Start()
    {
        btnCommandCenter.onClick.AddListener(BuildCommandCenter);
        btnEnergyGen.onClick.AddListener(BuildEnergyGen);
        btnMine.onClick.AddListener(BuildMine);
        btnStorage.onClick.AddListener(BuildStorage);

        area = GetComponent<AreaSelection>();
    }



    void LateUpdate()
    {
        if (targetT != null && !buildingPlaced)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Destroy(targetT.gameObject);
                buildingPlaced = true;
                targetT = null;
                return;
            }
            else if(Input.GetKeyDown(KeyCode.Comma)){
                rot -=90;
            }
            else if (Input.GetKeyDown(KeyCode.Period)){
                rot +=90;
            }
            targetT.position = new Vector3(((int)PointAndClick.TerrainMouseLocation.x), (int)PointAndClick.TerrainMouseLocation.y, ((int)PointAndClick.TerrainMouseLocation.z));
            targetT.rotation = Quaternion.Euler(90, rot, 0);
            ExtDebug.DrawBoxCastBox(new Vector3(targetT.position.x, targetT.position.y + 7, targetT.position.z), new Vector3(area.size.x / 2, 0.01f, area.size.y / 2), Quaternion.Euler(0, rot, 0), Vector3.down, 6.9f, new Color(0, 0, 1, 0.7f));
            if (Physics.BoxCast(new Vector3(targetT.position.x, targetT.position.y + 7, targetT.position.z), new Vector3(area.size.x / 2, 0.01f, area.size.y / 2), Vector3.down, Quaternion.Euler(0, rot, 0), 6.9f))
            {
                targetT.GetComponent<Renderer>().material.mainTexture = area.RedTex;
            }
            else
            {
                targetT.GetComponent<Renderer>().material.mainTexture = area.GreenTex;
                if (Input.GetMouseButtonDown(0))
                {
                    buildingPlaced = true;
                }
            }


        }
    }
    #region Command Center Builder 
    void BuildCommandCenter()
    {
        if (GameManager.current.Resources.HasCost(GameManager.current.buildingsManager.commandCenterData.buildingCosts))
            StartCoroutine(PlaceCommandCenter());
    }
    IEnumerator PlaceCommandCenter()
    {

        targetT = area.StartInst(GameManager.current.buildingsManager.commandCenterData.buildingSize);
        buildingPlaced = false;
        PointAndClick.cast = true;

        yield return new WaitUntil(NoTarget);
        PointAndClick.cast = false;
        if (targetT != null)
        {
            Vector3 pos = new Vector3(targetT.position.x,targetT.position.y,targetT.position.z);
            Destroy(targetT.gameObject);
            CreateCCModel(pos);
            rot = 0;
        }
    }
    void CreateCCModel(Vector3 pos)
    {
        BuildingRunner t = GameManager.current.buildingsManager.commandCenterData.CreateInst().AddComponent<CommandCenterRunner>();
        t.transform.position = pos;
        t.transform.rotation = Quaternion.Euler(0, rot, 0);
        GameManager.current.buildingsManager.Count++;
        GameManager.current.Resources.SpendCost(GameManager.current.buildingsManager.commandCenterData.buildingCosts);
        GameManager.current.buildingsManager.buildings.CommandCenters.Add(t as CommandCenterRunner);
    }
    #endregion

    #region Energy Generator Builder
    void BuildEnergyGen()
    {
        if (GameManager.current.Resources.HasCost(GameManager.current.buildingsManager.energyGenData.buildingCosts))
            StartCoroutine(PlaceEnergyGen());
    }
    IEnumerator PlaceEnergyGen()
    {
        targetT = area.StartInst(GameManager.current.buildingsManager.energyGenData.buildingSize);
        buildingPlaced = false;
        PointAndClick.cast = true;

        yield return new WaitUntil(NoTarget);
        PointAndClick.cast = false;
        if (targetT != null)
        {
            Vector3 pos = targetT.position;
            Destroy(targetT.gameObject);
            CreateEGModel(pos);
            rot = 0;
        }
    }
    void CreateEGModel(Vector3 pos)
    {
        BuildingRunner t = GameManager.current.buildingsManager.energyGenData.CreateInst().AddComponent<EnergyGeneratorRunner>();
        t.transform.position = pos;
        t.transform.rotation = Quaternion.Euler(0, rot, 0);
        GameManager.current.buildingsManager.Count++;
        GameManager.current.Resources.SpendCost(GameManager.current.buildingsManager.energyGenData.buildingCosts);
        GameManager.current.buildingsManager.buildings.EnergyGenerators.Add(t as EnergyGeneratorRunner);
    }
    #endregion

    #region Storage Building Builder
    void BuildStorage()
    {
        if (GameManager.current.Resources.HasCost(GameManager.current.buildingsManager.storageData.buildingCosts))
            StartCoroutine(PlaceStorage());
    }
    IEnumerator PlaceStorage()
    {
        targetT = area.StartInst(GameManager.current.buildingsManager.storageData.buildingSize);
        buildingPlaced = false;
        PointAndClick.cast = true;

        yield return new WaitUntil(NoTarget);
        PointAndClick.cast = false;
        if (targetT != null)
        {
            Vector3 pos = targetT.position;
            Destroy(targetT.gameObject);
            CreateSModel(pos);
            rot = 0;
        }
    }
    void CreateSModel(Vector3 pos)
    {
        BuildingRunner t = GameManager.current.buildingsManager.storageData.CreateInst().AddComponent<StorageRunner>();
        t.transform.position = pos;
        GameManager.current.buildingsManager.Count++;
        GameManager.current.Resources.SpendCost(GameManager.current.buildingsManager.storageData.buildingCosts);
        GameManager.current.buildingsManager.buildings.Storages.Add(t as StorageRunner);
    }
    #endregion

    #region Mine Facility Builder


    void BuildMine()
    {
        if (GameManager.current.Resources.HasCost(GameManager.current.buildingsManager.mineData.buildingCosts))
            StartCoroutine(PlaceMine());
    }
    IEnumerator PlaceMine()
    {
        targetT = area.StartInst(GameManager.current.buildingsManager.mineData.buildingSize);
        buildingPlaced = false;
        PointAndClick.cast = true;

        yield return new WaitUntil(NoTarget);
        PointAndClick.cast = false;
        if (targetT != null)
        {
            Vector3 pos = targetT.position;
            
            Destroy(targetT.gameObject);
            CreateMModel(pos);
            rot = 0;
        }
    }
    void CreateMModel(Vector3 pos)
    {
        BuildingRunner t = GameManager.current.buildingsManager.mineData.CreateInst().AddComponent<MineRunner>();
        t.transform.rotation = Quaternion.Euler(0, rot, 0);
        t.transform.Rotate(0, 180, 0);
        t.transform.position = pos;
        GameManager.current.buildingsManager.Count++;
        GameManager.current.Resources.SpendCost(GameManager.current.buildingsManager.mineData.buildingCosts);
        GameManager.current.buildingsManager.buildings.Mines.Add(t as MineRunner);
    }
    #endregion

    bool NoTarget()
    {
        if (buildingPlaced)
            return true;
        return false;
    }

    public class BuildingRunner : MonoBehaviour
    {
        protected BuildingUnit _data;
        public float health;
        public Vector2Int size;
    }

    public class CommandCenterRunner : BuildingRunner
    {

        private BuildingUnit Data
        {
            set
            {
                if (_data != null)
                {
                    GameManager.current.Resources.Capacity -= (int)_data.properties[2].value;
                }
                _data = value;
                GameManager.current.Resources.Capacity += (int)value.properties[2].value;

            }
            get
            {
                return _data;
            }
        }
        public int level = 1;
        public bool hasManager;
        public int unitsHoused;
        public int workersCount;
        private void Start()
        {
            print("CC Mono is working");
            Data = GameManager.current.buildingsManager.commandCenterData;

            health = Data.maxHealth;
            hasManager = true;
            workersCount = 2;
            unitsHoused = 3;
            size = Data.buildingSize;
        }


    }

    public class MineRunner : BuildingRunner
    {
        private BuildingUnit Data
        {
            set
            {
                if (_data != null)
                {
                    GameManager.current.Resources.Capacity -= (int)_data.properties[1].value;
                }
                _data = value;
                GameManager.current.Resources.Capacity += (int)value.properties[1].value;

            }
            get
            {
                return _data;
            }
        }
        public int level = 1;
        public int workersCount;
        private void Start()
        {
            print("CC Mono is working");
            Data = GameManager.current.buildingsManager.mineData;

            health = Data.maxHealth;
            workersCount = 0;
            size = Data.buildingSize;
        }
    }

    public class EnergyGeneratorRunner : BuildingRunner
    {
        private BuildingUnit Data
        {
            set
            {
                _data = value;
            }
            get
            {
                return _data;
            }
        }
        public int level = 1;
        public bool hasManager;
        public int workersCount;
        public int energyCapacity;
        private void Start()
        {
            Data = GameManager.current.buildingsManager.energyGenData;

            health = Data.maxHealth;
            hasManager = false;
            workersCount = 0;
            size = Data.buildingSize;
        }
    }

    public class StorageRunner : BuildingRunner
    {
        private BuildingUnit Data
        {
            set
            {
                if (_data != null)
                {
                    GameManager.current.Resources.Capacity -= (int)_data.properties[0].value;
                }
                _data = value;
                GameManager.current.Resources.Capacity += (int)value.properties[0].value;
            }
            get
            {
                return _data;
            }
        }
        public int level = 1;
        public int workersCount;
        private void Start()
        {
            print("CC Mono is working");
            Data = GameManager.current.buildingsManager.storageData;

            health = Data.maxHealth;
            workersCount = 0;
            size = Data.buildingSize;
        }
    }

}
