using UnityEngine;
using System.Collections;
using System;

public class PlayerMoveState : PlayerState {

    public PlayerMoveState(Player player, PlayerStateMachine stateMachine) {
        _stateMachine = stateMachine;
        _player = player;
    }

    public override IEnumerator Execute() {
        Debug.Log("MoveState");
        while (Input.GetButton("Horizontal") | Input.GetButton("Vertical")) {
            _player.Move();
            if (_player.IsGrounded && Input.GetButton("Jump")) {
                _stateMachine.ChangeState(PlayerStateMarkers.Jump);                
            }
            yield return null;
        }
        _stateMachine.ChangeState(PlayerStateMarkers.Idle);
    }
}
