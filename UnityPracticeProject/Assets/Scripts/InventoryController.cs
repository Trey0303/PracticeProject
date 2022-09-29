using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public static InventoryController Instance { get; set; }
    public PlayerWeaponController playerWeaponController;
    public ConsumableController consumableController;
    //public Item sword;
    //public Item potionLog;

    private void Start()
    {
        if(Instance != null && Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }

        playerWeaponController = GetComponent<PlayerWeaponController>();
        consumableController = GetComponent<ConsumableController>();
        //List<BaseStat> swordStats = new List<BaseStat>();
        //swordStats.Add(new BaseStat(6, "Power", "your power level"));
        //sword = new Item(swordStats, "Sword");
        //potionLog = new Item(new List<BaseStat>(), "potionLog", "drink this to log something", "Drink", "Log Potion", false);
    }

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.V))
    //    {
    //        playerWeaponController.EquipWeapon(sword);
    //        consumableController.ConsumeItem(potionLog);
    //    }

        
    //}
}
