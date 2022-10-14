using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Slime : MonoBehaviour, IEnemy
{
    NavMeshAgent navAgent; 
    public float curHealth;

    public float maxHealth = 20;

    private CharacterStat characterStat;

    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        characterStat = new CharacterStat(6,10,2);
        curHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        Debug.Log(amount);
        curHealth -= amount;
        if(curHealth <= 0)
        {
            Die();
        }
    }
    public void PerformAttack()
    {
        
    }

    void Die()
    {
        Destroy(gameObject);
    }

}
