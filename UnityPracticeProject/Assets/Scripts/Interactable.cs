using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Interactable : MonoBehaviour
{
    public NavMeshAgent playerAgent;

    //moves player to interacable object and interacts with it
    public virtual void MoveToInteraction(NavMeshAgent playerAgent)
    {
        //'this.playerAgent' grabs the playerAgent from this script, not the 'playerAgent' thats getting passed into this function from another script
        this.playerAgent = playerAgent;
        playerAgent.destination = this.transform.position;
        playerAgent.stoppingDistance = .7f;

        Interact();
    }

    public virtual void Interact()
    {
        Debug.Log("interacting with base class");
    }
}
