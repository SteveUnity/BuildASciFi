﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodLodge : buildingHealth
{
    /*
    public int woodYield = 10;
    public int level = 1;

    private bool active = false;
    public override bool IsActive
    {
        get
        {
            return active;
        }
        set
        {
            active = value;
            if (active)
            {
                GameManager.current.buildingsManager.woodLodgeManager.woodLodges.Add(this);
            }
            else
            {
                GameManager.current.buildingsManager.woodLodgeManager.woodLodges.Remove(this);
            }
        }
    }

    public void LevelUP()
    {
        if (GameManager.current.Resources.SpendCost(LevelUPCost()))
        {
            baseCost = LevelUPCost();
            level++;
            woodYield *= level;
        }
    }

    public Cost LevelUPCost()
    {
        int gold = baseCost.Wood * 2 + 5 * level;
        int wood = Mathf.RoundToInt(baseCost.Gold * 2 + 5 * level / 2f);
        int food = Mathf.RoundToInt(baseCost.Food * 2 + 5 * level / 2f);
        Cost cost = new Cost(gold, wood, food);

        return cost;
    }

    public override void TakeDamage(int val)
    {
        HP -= val;
        if (HP <= 0)
        {
            IsActive = false;
            Destroy(gameObject);
        }
    }*/
}
