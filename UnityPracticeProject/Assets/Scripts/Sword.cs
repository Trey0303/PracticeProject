using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour, IWeapon
{
    private Animator animator;
    public List<BaseStat> Stats { get; set; }
    public CharacterStat CharacterStat { get; set; }
    public int CurrentDamage { get; set; }

    void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void PerformAttack(int damage)
    {
        CurrentDamage = damage;
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
            col.GetComponent<IEnemy>().TakeDamage(CurrentDamage);
            //col.GetComponent<IEnemy>().TakeDamage(Stats[0].GetCalculatedStatValue());
        }
    }

}
