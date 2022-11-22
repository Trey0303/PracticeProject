using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

//base class for quests. will define properties and have some methods that all the quests will share.
public class Quest : MonoBehaviour
{
    public List<Goal> Goals { get; set; } = new List<Goal>();
    public string QuestName { get; set; }
    public string Description { get; set; }
    public int ExperienceReward { get; set; }
    public Item ItemReward { get; set; }
    public bool Completed { get; set; }

    public void CheckGoals()
    {
        Completed = Goals.All(g => g.Completed); ///this this a simpler way to write out everything thats commmeted out below

        

        //if (Goals.All(g => g.Completed))//if all goals are completed it will return true. if not then false
        //{
        //    Complete();
        //}
    }

    //void Complete()
    //{
    //    Completed = true;
    //}

    public void GiveReward()
    {
        if(ItemReward != null)
        {
            InventoryController.Instance.GiveItem(ItemReward);
        }
    }
}
