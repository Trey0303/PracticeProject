using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : NPC
{
    public bool AssignedQuest { get; set; }//will be true when the quest giver assigns the player a quest
    public bool Helped { get; set; }
    [SerializeField]
    private GameObject quests;
    [SerializeField]
    private string questType;
    public Quest Quest { get; set; }//reference to quest so that this script can know when quest has been completed
    public override void Interact()
    {
        //if quest giver has assigned the player a quest
        //if the player has help the npc by completing the quest
        if (!AssignedQuest && !Helped)
        {
            base.Interact();
            //assign quest to player
            AssignQuest();
        }
        else if (AssignedQuest && !Helped) {
            //check if quest is completed
            CheckQuest();
        }
        else
        {
            DialogueSystem.Instance.AddNewDialogue(new string[] { "Thanks for helping me get rid of all those monsters! " }, name);
        }
    }

    void AssignQuest()
    {
        AssignedQuest = true;
        Quest = (Quest)quests.AddComponent(System.Type.GetType(questType));
    }

    void CheckQuest()
    {
        if (Quest.Completed)
        {
            Quest.GiveReward();
            Helped = true;
            AssignedQuest = false;
            DialogueSystem.Instance.AddNewDialogue(new string[] { "Thanks for that! here is your reward! ", "More dialogue" }, name);
        }
        else
        {
            DialogueSystem.Instance.AddNewDialogue(new string[] { "Still need help! " }, name);
        }
    }
}
