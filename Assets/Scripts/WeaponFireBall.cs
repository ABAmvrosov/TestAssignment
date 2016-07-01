using UnityEngine;
using System.Collections;

public class WeaponFireBall : Weapon {

    public override void Shoot() {
        Debug.Log("FireBall shot");
    }

    public override string ToString() {
        return "FireBall";
    }
}
