using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : ActionItem
{
    public Vector3 TeleportLocation { get; set; }
    [SerializeField]
    private Portal[] linkedPortals;
    private PortalController Portal_Controller { get; set; }
    private void Start()
    {
        Portal_Controller = FindObjectOfType<PortalController>();
        TeleportLocation = new Vector3(transform.position.x + .5f,transform.position.y, transform.position.z);
    }

    public override void Interact()
    {
        Portal_Controller.ActivatePortal(linkedPortals);
        playerAgent.ResetPath();
    }
}
