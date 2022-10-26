﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterStat characterStat;

    public int curHealth;

    public int maxHealth;

    private void Start()
    {
        Debug.Log("Player init");
        curHealth = maxHealth;
        characterStat = new CharacterStat(10, 10, 10);
        UIEventHandler.HealthChanged(this.curHealth, maxHealth);//Update health in UI
    }

    public void TakeDamage(int amount)
    {
        Debug.Log(amount);
        curHealth -= amount;
        if (curHealth <= 0)
        {
            Die();
        }
        UIEventHandler.HealthChanged(this.curHealth, this.maxHealth);//update health in UI

    }

    void Die()
    {
        Debug.Log("player dead. reset health");
        curHealth = maxHealth;
        UIEventHandler.HealthChanged(this.curHealth, this.maxHealth);//update health in UI
    }
}
