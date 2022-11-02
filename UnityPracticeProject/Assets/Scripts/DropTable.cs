using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//youtube tutorial: https://www.youtube.com/watch?v=_MATbmNzKFk&list=PLivfKP2ufIK6ToVMtpc_KTHlJRZjuE1z0&index=23

/*
 Stuff to further help explain how this works:

    -http://www.vcskicks.com/random-element.php
    -https://www.google.com/search?q=cumulative+probability
 
 */

public class DropTable
{
    public List<LootDrop> loot;

    public Item GetDrop()
    {
        int roll = Random.Range(0, 101);
        int weightSum = 0;
        foreach(LootDrop drop in loot)
        {
            weightSum += drop.Weight;
            if(roll < weightSum)
            {
                return ItemDatabase.Instance.GetItem(drop.ItemSlug);
            }
        }

        return null;//if it doesnt find anythig
    }
}

public class LootDrop
{
    public string ItemSlug { get; set; }
    public int Weight { get; set; }


    public LootDrop(string itemSlug, int weight)
    {
        this.ItemSlug = itemSlug;
        this.Weight = weight;
    }
}
