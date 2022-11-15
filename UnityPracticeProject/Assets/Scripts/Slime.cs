using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Slime : MonoBehaviour, IEnemy
{
    public int ID { get; set; }
    public LayerMask aggroLayerMask;
    NavMeshAgent navAgent;
    public float curHealth;
    public float maxHealth = 20;

    public Spawner Spawner { get; set; }

    public int Experience { get; set; }
    public DropTable DropTable { get; set; }
    public PickupItem pickupItem;

    private Player player;
    private CharacterStat characterStat;
    private Collider[] withinAggroColliders;

    void Start()
    {
        DropTable = new DropTable();
        DropTable.loot = new List<LootDrop>
        {
            new LootDrop("Sword", 25),
            new LootDrop("Staff", 25),
            new LootDrop("PotionLog", 25)
        };
        ID = 0;
        Experience = 20;
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
        Debug.Log("Enemy takes " + amount + " damage!");
        curHealth -= amount;
        if(curHealth <= 0)
        {
            Die();
        }
    }
    public void Die()
    {
        DropLoot();
        CombatEvents.EnemyDied(this);
        this.Spawner.Respawn();
        Destroy(gameObject);
    }

    void DropLoot()
    {
        
        Item item = DropTable.GetDrop();//creates a temp item to store randomly selected item?
        if(item != null)//checks if there is a item to spawn
        {
            Debug.Log("Drop Loot!");
            PickupItem instance = Instantiate(pickupItem, transform.position, Quaternion.identity);//spawns itemdrop at enemy position
            instance.ItemDrop = item;//gives item stats?
        }
    }

    //void IEnemy.Die()
    //{
    //    //throw new System.NotImplementedException();
    //}
}
