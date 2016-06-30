using UnityEngine;
using System.Collections;

public class PlayerIdleState : PlayerState {
    
    public PlayerIdleState(Player player, PlayerStateMachine stateMachine) {
        _stateMachine = stateMachine;
        _player = player;
    }

    public override IEnumerator Execute() {
        Debug.Log("IdleState");
        while (true) {
            if (_player.IsGrounded && Input.GetButton("Jump")) {
                _stateMachine.ChangeState(PlayerStateMarkers.Jump);
                break;
            } else if (Input.GetButton("Horizontal") | Input.GetButton("Vertical")) {
                _stateMachine.ChangeState(PlayerStateMarkers.Move);
                break;
            }
            yield return null;
        }
    }
}
