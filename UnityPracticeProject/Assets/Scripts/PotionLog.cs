using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionLog : MonoBehaviour, IConsumable
{
    private Player player;

    public void Consume()
    {
        Debug.Log("you drank the potion");
        player = GameObject.Find("Player").GetComponent<Player>();
        
        if(player != null)
        {
            player.Heal(5);
        }

        Destroy(gameObject);
    }

    public void Consume(CharacterStat stats)
    {
        Debug.Log("drank potion");
    }
}
