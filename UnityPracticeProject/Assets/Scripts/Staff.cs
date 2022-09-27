using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staff : MonoBehaviour, IWeapon, IProjectileWeapon
{
    private Animator animator;
    public List<BaseStat> Stats { get; set; }
    public Transform ProjectileSpawn { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    Fireball fireball;

    void Start()
    {
        fireball = Resources.Load<Fireball>("Weapons/Projectiles/Fireball");
        animator = GetComponent<Animator>();
    }
    public void PerformAttack()
    {
        Debug.Log("staff attack!");
        
        animator.SetTrigger("BaseAttack");
    }

    public void PerformSpecialAttack()
    {
        Debug.Log("staff special attack!");
        animator.SetTrigger("SpecialAttack");
    }

    public void CastProjectile()
    {
        Fireball fireballInstance = Instantiate(fireball, ProjectileSpawn.position, ProjectileSpawn.rotation);
        fireballInstance.Direction = ProjectileSpawn.forward;
    }
}
