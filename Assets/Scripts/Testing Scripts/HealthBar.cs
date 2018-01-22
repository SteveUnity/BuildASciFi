using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {

    buildingHealth bh;
    public Transform HPV;

    float hp = 0;

	// Use this for initialization
	void Start () {
        bh = GetComponent<buildingHealth>();
        if (bh == null)
            Destroy(this);
        hp = bh.MaxHP;
	}
	
	// Update is called once per frame
	void Update () {
        if (HPV == null)
            return;
		if(bh.HP != hp && bh.HP!=0)
        {
            HPV.localScale = new Vector3(HPV.localScale.x, bh.HP/hp, HPV.localScale.z);
        }
	}
}
