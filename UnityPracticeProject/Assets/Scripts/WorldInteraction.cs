using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// a system used to detect interactions in the world when you click on something. 
/// 
/// this script will handle sending out a raycast from player camera and figuring out what it hit. then telling something else to do something depending on what it hit.
/// </summary>

public class WorldInteraction : MonoBehaviour
{
    NavMeshAgent playerAgent;

    private void Start()
    {
        playerAgent = GetComponent<NavMeshAgent>();
    }

    //checking for mouse input
    private void Update()
    {
        //                                      this checks if you are hovering over UI or not
        if (Input.GetMouseButtonDown(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
            GetInteraction();
        }
    }

    //handles checking what you are interacting with
    void GetInteraction()
    {
        //shoots a ray from camera to selected position
        Ray interactionRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit interactionInfo;//stores ray hit information information
        if (Physics.Raycast(interactionRay, out interactionInfo, Mathf.Infinity)){//gives my 'interationRay' info to physics.raycast. physics.raycast sends its result to 'interactionInfo'. Mathf.Infinity is just to set an infinite range for my ray so that it wont stop checking until it hits something
            GameObject interactedObject = interactionInfo.collider.gameObject;//gets the gameObject that raycast hits
            if(interactedObject.tag == "InteractableObj")//if player wants to interact with somthing
            {
                //Debug.Log("interactable object");
                interactedObject.GetComponent<Interactable>().MoveToInteraction(playerAgent);
            }
            else//if player is just walking
            {
                playerAgent.stoppingDistance = 0;
                playerAgent.destination = interactionInfo.point;
            }
        }
    }
}
