using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionLog : MonoBehaviour, IConsumable
{
    public void Consume()
    {
        Debug.Log("you drank the potion");
        Destroy(gameObject);
    }

    public void Consume(CharacterStat stats)
    {
        Debug.Log("drank potion");
    }
}
