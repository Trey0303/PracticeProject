using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour, IWeapon
{
    private Animator animator;
    public List<BaseStat> Stats { get; set; }
    public CharacterStat CharacterStat { get; set; }

    void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void PerformAttack()
    {
        Debug.Log("sword attack!");
        animator.SetTrigger("BaseAttack");
    }

    public void PerformSpecialAttack()
    {
        Debug.Log("sword special attack!");
        animator.SetTrigger("SpecialAttack");
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Enemy")
        {
            Debug.Log("Enemy hit");
            col.GetComponent<IEnemy>().TakeDamage(CharacterStat.GetStat(BaseStat.BaseStatType.Power).GetCalculatedStatValue());
            //col.GetComponent<IEnemy>().TakeDamage(Stats[0].GetCalculatedStatValue());
        }
    }
}
