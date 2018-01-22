using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildingHealth : MonoBehaviour {
    public int MaxHP = 100;
    public int HP;
    //public Cost baseCost;

    private bool isActive = false;
    public virtual bool IsActive
    {
        get
        {
            return isActive;
        }
        set
        {
            isActive = value;
        }
    }


    public virtual void TakeDamage(int val)
    {
        HP -= val;
        if(HP<=0)
        {
            Destroy(gameObject);
        }
    }
}
