﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : Interactable
{
    public override void Interact()
    {
        Debug.Log("interact with item");
    }
}