using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Interactable
{
    public string[] dialogue;//not the most efficient way to grab dialogue.(video metioned something about grabbing dialogue from text files)
#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
    public string name;
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword

    public override void Interact()
    {
        DialogueSystem.Instance.AddNewDialogue(dialogue, name);//gives dialogueSystem an array of strings for NPC dialogue
        Debug.Log("Interacting with NPC");
    }
}
