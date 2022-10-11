using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

public class BaseStat
{
    public enum BaseStatType { Power, Toughness, AttackSpeed}

    public List<StatBonus> BaseAdditives { get; set; }
    [JsonConverter(typeof(StringEnumConverter))]
    public BaseStatType StatType { get; set; }
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

    [Newtonsoft.Json.JsonConstructor]
    public BaseStat(BaseStatType statType, int baseValue, string statName)
    {
        this.BaseAdditives = new List<StatBonus>();
        this.StatType = statType;
        this.BaseValue = baseValue;
        this.StatName = statName;
    }

    public void AddStatBonus(StatBonus statBonus)
    {
        this.BaseAdditives.Add(statBonus);
    }

    public void RemoveStatBonus(StatBonus statBonus)
    {
        this.BaseAdditives.Remove(BaseAdditives.Find(x => x.BonusValue == statBonus.BonusValue));
    }

    /// <summary>
    /// GetCalculatedStatValue() Example: 
    ///          
    ///      Values-
    ///          BaseAdditive{3,4,5}
    ///          finalValue = 0;
    ///          baseValue = 10;         
    /// 
    ///      foreach lambda expression:
    ///             0               3 
    ///         1. finalValue + BaseAdditive[x = 0] = 3
    ///          
    ///             3               4
    ///         2.finalValue + BaseAdditive[x = 1] = 7
    ///         
    ///             7               5
    ///         3.finalValue + BaseAdditive[x = 2] = 12
    ///
    ///             12              10
    ///         4.finalValue + baseValue = 22
    ///         
    ///         5.return finalValue(22)
    /// </summary>
    /// <returns></returns>
    public int GetCalculatedStatValue()
    {
        this.FinalValue = 0;//reset finalValue
        //for each buff and debuff added to the baseAdditives list add it all up to the finalValue
        this.BaseAdditives.ForEach(x => this.FinalValue += x.BonusValue);//foreach lambda expression????(adds the bonusValue from the statBonus script to the FinalValue)

        FinalValue += BaseValue;//add the baseValue to the finalValue as well

        return FinalValue;//return the final calculation from adding bonus and base values
    }
}
