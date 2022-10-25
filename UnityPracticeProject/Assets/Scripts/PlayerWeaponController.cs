using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour
{
    public GameObject playerHand;
    public GameObject EquippedWeapon { get; set; }

    Transform spawnProjectile;
    Item currentlyEquippedItem;
    IWeapon equippedWeapon;
    CharacterStat characterStats;

    private void Start()
    {
        //should probably figure out a better way to find children transform
        //gameObject.Find() searches through the whole hierarchy which I dont really need in this situation. I just want it to find a specific childs transform in a gameObject that has this script attached.
        //the reason that transfom.Find() isnt working for me is because I had 'ProjectileSpawn' as a child of playermodel instead of player
        //video reference for later: https://www.youtube.com/watch?v=KhvokgokrQE
        spawnProjectile = transform.Find("ProjectileSpawn");
        //Debug.Log(spawnProjectile.position);
        characterStats = GetComponent<Player>().characterStat;
    }

    public void EquipWeapon(Item itemToEquip)
    {
        if(EquippedWeapon != null)//if there is already a weapon in playerHand
        {
            //add currently equipped weapon back to player inventory
            InventoryController.Instance.GiveItem(currentlyEquippedItem.ObjectSlug);
            //remove weapon stat bonus from player stats then delete weapon from playerHand
            characterStats.RemoveStatBonus(EquippedWeapon.GetComponent<IWeapon>().Stats);
            Destroy(playerHand.transform.GetChild(0).gameObject);
        }

        EquippedWeapon = Instantiate(Resources.Load<GameObject>("Weapons/" + itemToEquip.ObjectSlug), playerHand.transform.position, playerHand.transform.rotation);//spawn weapon from prefab/weapons folder into playerHand
        EquippedWeapon.transform.SetParent(playerHand.transform);//parent weapon to playerHand so that it will follow player whenever player moves
        
        //cant get this bit of code to work(edit: needed to equip the sword script to the sword GameObject in the Weapons folder)
        equippedWeapon = EquippedWeapon.GetComponent<IWeapon>();
        if(EquippedWeapon.GetComponent<IProjectileWeapon>() != null){
            EquippedWeapon.GetComponent<IProjectileWeapon>().ProjectileSpawn = spawnProjectile;
        }
        equippedWeapon.Stats = itemToEquip.Stats;//copy over weapon stats to instantiated weapon

        currentlyEquippedItem = itemToEquip;//updates reference to currently equipped item for later use

        characterStats.AddStatBonus(itemToEquip.Stats);
        //Debug.Log(equippedWeapon.Stats[0].GetCalculatedStatValue());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            PerformWeaponAttack();
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            PerformSpecialWeaponAttack();
        }
    }

    public void PerformWeaponAttack()
    {
        equippedWeapon.PerformAttack(CalculatedDamage());
    }

    public void PerformSpecialWeaponAttack()
    {
        equippedWeapon.PerformSpecialAttack();
    }

    private int CalculatedDamage()
    {
        int damageToDeal = (characterStats.GetStat(BaseStat.BaseStatType.Power).GetCalculatedStatValue() * 2) +
            Random.Range(2, 8);
        damageToDeal += CalculateCrit(damageToDeal);
        Debug.Log("Damage dealt: " + damageToDeal);
        return damageToDeal;
    }

    private int CalculateCrit(int damage) {
        if(Random.value <= .10f)
        {
            int critDamage = (int)(damage * Random.Range(.5f, .75f));
            return critDamage;
        }
        return 0;
    }
}
