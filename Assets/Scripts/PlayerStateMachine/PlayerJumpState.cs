using UnityEngine;
using System.Collections;
using System;

public class PlayerJumpState : PlayerState {

    public PlayerJumpState(Player player, PlayerStateMachine stateMachine) {
        _stateMachine = stateMachine;
        _player = player;
    }

    public override IEnumerator Execute() {
        Debug.Log("JumpState");
        _player.IsGrounded = false;
        _player.Jump();
        _stateMachine.ChangeState(PlayerStateMarkers.Fall);
        yield return null;
    }
}
