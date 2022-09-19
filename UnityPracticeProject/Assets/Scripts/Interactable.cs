using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Interactable : MonoBehaviour
{
    [HideInInspector]
    public NavMeshAgent playerAgent;
    private bool hasInteracted;//prevents Interact() from being call more than once unexpectedly

    //moves player to interacable object and interacts with it
    public virtual void MoveToInteraction(NavMeshAgent playerAgent)
    {
        hasInteracted = false;
        //'this.playerAgent' grabs the playerAgent from this script, not the 'playerAgent' thats getting passed into this function from another script
        this.playerAgent = playerAgent;
        playerAgent.destination = this.transform.position;
        playerAgent.stoppingDistance = .7f;

    }

    private void Update()
    {
        //everything inside this if statement should prevent Interact() from being called until player reaches their destination
        if(!hasInteracted && playerAgent != null && !playerAgent.pathPending)//checks if player has a navMesh agent and if its Not still trying to search for a path for the player to move to
        {
            if(playerAgent.remainingDistance <= playerAgent.stoppingDistance)//checks distance between player and destination. also accounts for stopping distances
            {
                Interact();
                hasInteracted = true;
            }
        }
    }
    public virtual void Interact()
    {
        Debug.Log("interacting with base class");
    }
}
