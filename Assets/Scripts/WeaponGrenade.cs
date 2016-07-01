using UnityEngine;
using System.Collections;

public class WeaponGrenade : Weapon {

    public override void Shoot() {
        Debug.Log("Greande shot");
    }

    public override string ToString() {
        return "Grenade";
    }
}
