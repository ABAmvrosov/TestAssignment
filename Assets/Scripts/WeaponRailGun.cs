using UnityEngine;
using System.Collections;
using System;

public class WeaponRailGun : Weapon {

    public override void Shoot() {
        Debug.Log("RailGun shot");
    }

    public override string ToString() {
        return "RailGun";
    }
}
