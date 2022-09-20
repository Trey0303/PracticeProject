using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStat : MonoBehaviour
{
    public List<BaseStat> stats = new List<BaseStat>();

    private void Start()
    {
        stats.Add(new BaseStat(4, "Power", "Your power level"));
        stats.Add(new BaseStat(2, "Vitality", "Your vitality level."));
        //stats[0].AddStatBonus(new StatBonus(5));
        //stats[0].AddStatBonus(new StatBonus(-7));
        //stats[0].AddStatBonus(new StatBonus(21));
        //Debug.Log(stats[0].GetCalculatedStatValue());
    }

    public void AddStatBonus(List<BaseStat> StatBonuses)//will be used to add weapon stat bonuses
    {
        foreach(BaseStat statBonus in StatBonuses)
        {
            stats.Find(x => x.StatName == statBonus.StatName).AddStatBonus(new StatBonus(statBonus.BaseValue));
        }
    }

    public void RemoveStatBonus(List<BaseStat> StatBonuses)//will be used to Remove weapon stat bonuses
    {
        foreach (BaseStat statBonus in StatBonuses)
        {
            stats.Find(x => x.StatName == statBonus.StatName).RemoveStatBonus(new StatBonus(statBonus.BaseValue));
        }
    }
}
