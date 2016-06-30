using System.Collections;
using UnityEngine;
using System;

public class PlayerState {

    protected PlayerStateMachine _stateMachine;
    protected Player _player;

    public virtual IEnumerator Execute() {
        while (true) {
            if (Input.GetButtonDown("Fire1"))
                Debug.Log("Fire");
            yield return null;
        }
    }
}
