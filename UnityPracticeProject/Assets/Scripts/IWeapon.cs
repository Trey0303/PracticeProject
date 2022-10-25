using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon//intreface??
{
    List<BaseStat> Stats { get; set; }
    //CharacterStat CharacterStat { get; set; }
    int CurrentDamage { get; set; }
    void PerformAttack(int damage);

    void PerformSpecialAttack();
}
