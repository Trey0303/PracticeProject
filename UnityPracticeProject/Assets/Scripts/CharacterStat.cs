using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStat
{
    public List<BaseStat> stats = new List<BaseStat>();

    public CharacterStat(int power, int toughness, int attackSpeed)
    {
        stats = new List<BaseStat>() {
            new BaseStat(BaseStat.BaseStatType.Power, power, "Power"),
            new BaseStat(BaseStat.BaseStatType.Toughness, toughness, "Toughness"),
            new BaseStat(BaseStat.BaseStatType.AttackSpeed, attackSpeed, "Atk Spd"),
        };
    }

    //private void Start()
    //{
    //    stats.Add(new BaseStat(4, "Power", "Your power level"));
    //    stats.Add(new BaseStat(2, "Vitality", "Your vitality level."));
    //    //stats[0].AddStatBonus(new StatBonus(5));
    //    //stats[0].AddStatBonus(new StatBonus(-7));
    //    //stats[0].AddStatBonus(new StatBonus(21));
    //    //Debug.Log(stats[0].GetCalculatedStatValue());
    //}

    public BaseStat GetStat(BaseStat.BaseStatType stat)
    {
        return this.stats.Find(x => x.StatType == stat);
    }

    public void AddStatBonus(List<BaseStat> StatBonuses)//will be used to add weapon stat bonuses
    {
        foreach(BaseStat statBonus in StatBonuses)
        {
            GetStat(statBonus.StatType).AddStatBonus(new StatBonus(statBonus.BaseValue));
            //stats.Find(x => x.StatName == statBonus.StatName).AddStatBonus(new StatBonus(statBonus.BaseValue));
        }
    }

    public void RemoveStatBonus(List<BaseStat> StatBonuses)//will be used to Remove weapon stat bonuses
    {
        foreach (BaseStat statBonus in StatBonuses)
        {
            GetStat(statBonus.StatType).RemoveStatBonus(new StatBonus(statBonus.BaseValue));
            //stats.Find(x => x.StatName == statBonus.StatName).RemoveStatBonus(new StatBonus(statBonus.BaseValue));
        }
    }
}
