using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public Vector3 Direction { get; set; }
    public float Range { get; set; }
    public int Damage { get; set; }

    private void Start()
    {
        GetComponent<Rigidbody>().AddForce(Direction * 50);
    }
}
