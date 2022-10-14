using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterStat characterStat;

    public float curHealth;

    public float maxHealth;

    private void Start()
    {
        curHealth = maxHealth;
        characterStat = new CharacterStat(10, 10, 10);
    }

    public void TakeDamage(int amount)
    {
        Debug.Log(amount);
        curHealth -= amount;
        if (curHealth <= 0)
        {
            Die();
        }

        void Die()
        {
            Debug.Log("player dead. reset health");
            curHealth = maxHealth;
        }
    }
}
