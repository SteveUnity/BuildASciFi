using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavFollowObject : MonoBehaviour {

    public GameObject target;
    public NavMeshAgent unit;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        unit.SetDestination(target.transform.position);
	}
}
