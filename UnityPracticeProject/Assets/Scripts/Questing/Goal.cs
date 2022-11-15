using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//quest goal will have a description, a boolean for knowing if the quest is completed, 
//and the ability to keep track of an amount of something and compare that to how much is need to complete the quest(quest ex: collect 5 bolts, current amount is 0)
public class Goal
{
    public string Description { get; set; }
    public bool Completed { get; set; }
    public int CurrentAmount { get; set; }
    public int RequiredAmount { get; set; }

    public virtual void Init()
    {
        //defaults
    }

    public void Evaluate()
    {
        if(CurrentAmount >= RequiredAmount)//if player met requirement
        {
            Complete();//complete the quest
        }
    }

    public void Complete()
    {
        Completed = true;
    }
}
