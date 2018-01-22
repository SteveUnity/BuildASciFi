using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fence : buildingHealth
{

    //public Cost baseCost;
    public int level = 1;

    private bool active = false;
    public override bool IsActive
    {
        get
        {
            return active;
        }
       /* set
        {
            active = value;
            if (active)
            {
                GameManager.current.buildingsManager.fenceManager.fences.Add(this);
            }
            else
            {
                GameManager.current.buildingsManager.fenceManager.fences.Remove(this);
            }
        }*/
    }
    /*

    public void LevelUP()
    {
        if (GameManager.current.Resources.SpendCost(LevelUPCost()))
        {
            baseCost = LevelUPCost();
            level++;
        }
    }

    public Cost LevelUPCost()
    {
        int wood = Mathf.CeilToInt(baseCost.Wood * 2 + 5 * level / 2f)*2;
        int food = Mathf.CeilToInt(baseCost.Food * 2 + 5 * level / 2f);
        Cost cost = new Cost(0, wood, food);

        return cost;
    }
    */
    public override void TakeDamage(int val)
    {
        HP -= val;
        if (HP <= 0)
        {
            IsActive = false;
            Destroy(gameObject);
        }
    }
}
