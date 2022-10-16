using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BFGPower : Weapon
{
    public GameObject weaponTrailEffect;

    public override void Activate()
    {
        MegaAttack(weaponTrailEffect, GameObject.FindGameObjectWithTag("Player"));
    }
}
