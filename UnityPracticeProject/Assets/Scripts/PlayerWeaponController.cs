using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour
{
    public GameObject playerHand;
    public GameObject EquippedWeapon { get; set; }

    IWeapon equippedWeapon;
    CharacterStat characterStats;

    private void Start()
    {
        characterStats = GetComponent<CharacterStat>();
    }

    public void EquipWeapon(Item itemToEquip)
    {
        if(EquippedWeapon != null)//if there is already a weapon in playerHand
        {
            //remove weapon stat bonus from player stats then delete weapon from playerHand
            characterStats.RemoveStatBonus(EquippedWeapon.GetComponent<IWeapon>().Stats);
            Destroy(playerHand.transform.GetChild(0).gameObject);
        }

        EquippedWeapon = Instantiate(Resources.Load<GameObject>("Weapons/" + itemToEquip.ObjectSlug), playerHand.transform.position, playerHand.transform.rotation);//spawn weapon from prefab/weapons folder into playerHand
        EquippedWeapon.transform.SetParent(playerHand.transform);//parent weapon to playerHand so that it will follow player whenever player moves
        
        //cant get this bit of code to work(edit: needed to equip the sword script to the sword GameObject in the Weapons folder)
        equippedWeapon = EquippedWeapon.GetComponent<IWeapon>();
        equippedWeapon.Stats = itemToEquip.Stats;//copy over weapon stats to instantiated weapon
        
        
        characterStats.AddStatBonus(itemToEquip.Stats);
        Debug.Log(equippedWeapon.Stats[0].GetCalculatedStatValue());
    }

    public void PerformWeaponAttack()
    {
        equippedWeapon.PerformAttack();
    }
}
