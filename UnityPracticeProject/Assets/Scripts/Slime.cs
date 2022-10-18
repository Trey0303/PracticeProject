using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Slime : MonoBehaviour, IEnemy
{
    public LayerMask aggroLayerMask;
    NavMeshAgent navAgent; 
    public float curHealth;

    public float maxHealth = 20;

    private Player player;
    private CharacterStat characterStat;
    private Collider[] withinAggroColliders;

    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        characterStat = new CharacterStat(6,10,2);
        curHealth = maxHealth;
    }

    void FixedUpdate()
    {
        //creates a sphere around enemy to check if player is in aggro range
        withinAggroColliders = Physics.OverlapSphere(transform.position, 5, aggroLayerMask);
        if(withinAggroColliders.Length > 0)
        {
            Debug.Log("found player");
            ChasePlayer(withinAggroColliders[0].GetComponent<Player>());
        }
    }

    
    void ChasePlayer(Player player)
    {
        navAgent.SetDestination(player.transform.position);//sets a path to get to the player
        this.player = player;
        if(navAgent.remainingDistance <= navAgent.stoppingDistance)//checks remaining distance on the path
        {
            if (!IsInvoking("PerformAttack"))//if not attacking
            {
                InvokeRepeating("PerformAttack", .5f, 2f);//attack

            }
            
        }
        else
        {
            //Debug.Log("Not within distance");
            CancelInvoke();//stop attacking if not within attack range
        }

    }
    
    public void PerformAttack()
    {
        player.TakeDamage(5);
    }


    public void TakeDamage(int amount)
    {
        Debug.Log("player takes " + amount + " damage!");
        curHealth -= amount;
        if(curHealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }

}
