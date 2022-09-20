﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStat : MonoBehaviour
{
    public List<BaseStat> stats = new List<BaseStat>();

    private void Start()
    {
        stats.Add(new BaseStat(4, "Power", "Your power level"));
        stats[0].AddStatBonus(new StatBonus(5));
        stats[0].AddStatBonus(new StatBonus(-7));
        stats[0].AddStatBonus(new StatBonus(21));
        Debug.Log(stats[0].GetCalculatedStatValue());
    }
}
