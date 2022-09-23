using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour, IEnemy
{
    public float curHealth, power, toughness;

    private float maxHealth = 20;

    void Start()
    {
        curHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
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
