using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterStat characterStat;

    private void Start()
    {
        characterStat = new CharacterStat(10, 10, 10);
    }
}
