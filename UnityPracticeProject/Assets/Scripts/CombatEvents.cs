using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatEvents : MonoBehaviour
{
    public delegate void EnemyEventhandler(IEnemy enemy);
    public static event EnemyEventhandler OnEnemyDeath;

    public static void EnemyDied(IEnemy enemy)
    {
        if(OnEnemyDeath != null)
        {
            OnEnemyDeath(enemy);
        }
    }
}
