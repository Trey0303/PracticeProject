using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEventHandler : MonoBehaviour
{
    //used to update items in UI
    public delegate void ItemEventHandler(Item item);
    public static event ItemEventHandler OnItemAddedToInventory;
    public static event ItemEventHandler OnItemEquipped;

    //used to update Health in UI
    public delegate void PlayerHealthEventHandler(int currentHealth, int maxHealth);
    public static event PlayerHealthEventHandler OnPlayerHealthChanged;

    //used to update Stats in UI
    public delegate void StatsEventHandler();
    public static event StatsEventHandler OnStatsChanged;

    //used to update level in UI
    public delegate void PlayerLevelEventHandler();
    public static event PlayerLevelEventHandler OnPlayerLevel;

    public static void ItemAddedToInventory(Item item)
    {
        OnItemAddedToInventory(item);
    }

    public static void ItemEquipped(Item item)
    {
        OnItemEquipped(item);
    }

    public static void HealthChanged(int currentHealth, int maxHealth)
    {
        OnPlayerHealthChanged(currentHealth, maxHealth);
    }

    public static void StatsChanged()
    {
        OnStatsChanged();
    }

    public static void PlayerLeveled()
    {
        OnPlayerLevel();
    }
}
