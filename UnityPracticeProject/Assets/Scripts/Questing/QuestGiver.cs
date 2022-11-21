using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : NPC
{
    public bool AssignedQuest { get; set; }//will be true when the quest giver assigns the player a quest

    public override void Interact()
    {
        base.Interact();
        //if quest giver has assigned the player a quest
        //if the player has help the npc by completing the quest
    }
}
