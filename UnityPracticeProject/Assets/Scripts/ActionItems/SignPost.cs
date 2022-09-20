using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignPost : ActionItem
{
    public string[] dialogue;
    public override void Interact()
    {
        //base.Interact(); would call the default Interact() inside the ActionItem script. then it would also call the Interact function inside this script after

        DialogueSystem.Instance.AddNewDialogue(dialogue,"sign");
        Debug.Log("interacting with sign post");
    }
}
