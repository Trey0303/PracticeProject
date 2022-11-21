using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterQuest : Quest
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("monster quest assigned");
        QuestName = "monster extermination 1";
        Description = "eliminate a bunch of slime monsters.";
        ItemReward = ItemDatabase.Instance.GetItem("potionLog");
        ExperienceReward = 100;

        Goals.Add(new KillGoal(this, 0, "kill 5 Slimes", false, 0, 1));
        Goals.Add(new KillGoal(this, 1, "kill 5 Blue Slime", false, 0, 1));

        Goals.ForEach(g => g.Init());

    }

}
