using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PortalController : MonoBehaviour
{
    public Button button;
    private Portal[] portal;
    private Player player;
    private GameObject panel;
    public WorldInteraction playerNavMeshRef;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        panel = transform.Find("Panel_Portals").gameObject;
        playerNavMeshRef = player.GetComponent<WorldInteraction>();
    }

    public void ActivatePortal(Portal[] portals)
    {
        foreach (Button button in GetComponentsInChildren<Button>())//deletes any exiting warp buttons
        {
            Destroy(button.gameObject);
        }
        panel.SetActive(true);
        for (int i = 0; i < portals.Length; i++){
            Button portalButton = Instantiate(button, panel.transform);
            portalButton.GetComponentInChildren<Text>().text = portals[i].name;
            int x = i;
            portalButton.onClick.AddListener(delegate { OnPortalButtonClick(portals[x]); });//this will trigger when player clicks a Button
        }
    }

    void OnPortalButtonClick(Portal portal)
    {
        playerNavMeshRef.playerAgent.enabled = false;
        player.transform.position = portal.TeleportLocation;
        foreach (Button button in GetComponentsInChildren<Button>())//deletes existing portal buttons
        {
            Destroy(button.gameObject);
        }
        panel.SetActive(false);
        playerNavMeshRef.playerAgent.enabled = true;
    }
}
