using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseStat
{
    public List<StatBonus> BaseAdditives { get; set; }
    public int BaseValue { get; set; }//starting stat
    public string StatName { get; set; }
    public string StatDescription { get; set; }
    public int FinalValue { get; set; }//a value that takes the starting stat and calculates it with buffs and defuffs accordingly

    public BaseStat(int baseValue, string statName, string statDescription)
    {
        this.BaseAdditives = new List<StatBonus>();
        this.BaseValue = baseValue;
        this.StatName = statName;
        this.StatDescription = statDescription;
    }
    
    public void AddStatBonus(StatBonus statBonus)
    {
        this.BaseAdditives.Add(statBonus);
    }

    public void RemoveStatBonus(StatBonus statBonus)
    {
        this.BaseAdditives.Remove(statBonus);
    }

    public int GetCalculatedStatValue()
    {
        this.BaseAdditives.ForEach(x => this.FinalValue += x.BonusValue);//????

        FinalValue += BaseValue;

        return FinalValue;
    }
}
