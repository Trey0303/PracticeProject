using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon//intreface??
{
    List<BaseStat> Stats { get; set; }
    void PerformAttack();
}
