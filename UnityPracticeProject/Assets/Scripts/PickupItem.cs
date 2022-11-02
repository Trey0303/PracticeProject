using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : Interactable
{
    public Item ItemDrop { get; set; }

    public override void Interact()
    {
        Debug.Log("interact with item");
        InventoryController.Instance.GiveItem(ItemDrop);
        Destroy(gameObject);
    }
}
