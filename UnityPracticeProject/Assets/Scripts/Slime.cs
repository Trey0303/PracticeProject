using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour, IEnemy
{
    public float curHealth, power, toughness;

    public float maxHealth = 20;

    private CharacterStat characterStat;

    void Start()
    {
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
