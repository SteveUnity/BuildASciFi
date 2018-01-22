using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitAttack : MonoBehaviour {

    public buildingHealth target;
    public Material red;
    public Material white;

    Renderer renderer;

    bool IsAttacking = false;
    bool isAttacking { get { return IsAttacking; }set { IsAttacking = value; } }
    bool isTracking = false;
	// Use this for initialization
	void Start () {
        renderer = transform.GetChild(0).GetComponent<Renderer>();
	}
    private void Update()
    {
        
    }

    // Update is called once per frame


    private void OnTriggerEnter(Collider other)
    {
        print("OnTriggerEnter");
        if (!isAttacking)
        {
            target = other.GetComponent<buildingHealth>();
            if(target != null)
            {
                GetComponent<NavMeshAgent>().isStopped = true;
                isAttacking = true;
                InvokeRepeating("prepareAttack", 0, 0.5f);
                InvokeRepeating("Attack", 0.1f, 0.5f);

            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        print("OnTriggerEnter");
        if (target == null)
        {
            GetComponent<NavMeshAgent>().isStopped = false;
            isAttacking = false;
            isTracking = false;
            CancelInvoke();
        }
    }
    void prepareAttack()
    {
        renderer.material = red;
    }
    void Attack()
    {
        if (target == null)
        {
            GetComponent<NavMeshAgent>().isStopped = false;
            isAttacking = false;
            isTracking = false;
            CancelInvoke();
            renderer.material = white;
            return;
        }
        target.TakeDamage(5);
        renderer.material = white;
    }
}
