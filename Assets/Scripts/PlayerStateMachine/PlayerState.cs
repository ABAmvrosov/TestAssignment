using System.Collections;
using UnityEngine;
using System;

public class PlayerState {

    protected PlayerStateMachine _stateMachine;
    protected Player _player;

    public PlayerState() { }

    public PlayerState(Player player, PlayerStateMachine stateMachine) {
        _stateMachine = stateMachine;
        _player = player;
    }

    public virtual IEnumerator Execute() {
        while (true) {
            if (Input.GetButtonDown("Fire1"))
                _player.Shoot();
            if (Input.GetAxis("Mouse ScrollWheel") != 0)
                _player.ChangeWeapon();
            yield return null;
        }
    }
}
