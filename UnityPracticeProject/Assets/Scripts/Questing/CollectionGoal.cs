using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionGoal : Goal
{
    public string ItemID { get; set; }

    public CollectionGoal(Quest quest, string itemID, string description, bool completed, int currentAmount, int requireAmount)
    {
        this.Quest = quest;
        this.ItemID = itemID;
        this.Description = description;
        this.Completed = completed; 
        this.CurrentAmount = currentAmount;
        this.RequiredAmount = requireAmount;
    }

    public override void Init()
    {
        base.Init();
        UIEventHandler.OnItemAddedToInventory += ItemPickedUp;
    }

    void ItemPickedUp(Item item)
    {
        if(item.ObjectSlug == this.ItemID)//if the item we picked up has an ID matching the quests required itemID
        {
            this.CurrentAmount++;//increase the current amount 
            Evaluate();//then check if player has completed all quest requirements
        }
    }

}
