using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CreateUnits : MonoBehaviour {

    public GameObject unit;
    public Vector3 SummonLoc;

    public List<GameObject> summoned = new List<GameObject>();

    public bool create = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (unit == null)
            return;
        if (create)
        {
            GameObject unitInst = Instantiate(unit, transform.position, Quaternion.identity);
            summoned.Add(unitInst);
            
            unitInst.GetComponent<NavMeshAgent>().SetDestination(SummonLoc);
            create = false;
        }
	}
}
