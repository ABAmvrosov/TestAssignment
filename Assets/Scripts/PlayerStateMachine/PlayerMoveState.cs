using UnityEngine;
using System.Collections;
using System;

public class PlayerMoveState : PlayerState {
    
    private WaitForSeconds _wait;

    private void Awake() {
        _wait = new WaitForSeconds(0.1f);
        _stateMachine = GetComponent<PlayerStateMachine>();
        _player = GetComponent<Player>();
    }

    public override IEnumerator Execute() {
        Debug.Log("MoveState");
        Messenger.Broadcast("Move");
        while (true) {
            if (_player.IsGrounded && Input.GetButton("Jump")) {
                _player.IsMoving = false;
                _stateMachine.ChangeState(PlayerStateMarkers.Jump);
                break;
            }
            if (!Input.GetButton("Horizontal") & !Input.GetButton("Vertical")) {
                _stateMachine.ChangeState(PlayerStateMarkers.Idle);
                _player.IsMoving = false;
                break;
            }
            yield return null;
        }
    }
}
