using UnityEngine;
using System.Collections;

public class PlayerIdleState : PlayerState {
    
    private WaitForSeconds _wait;

    private void Awake() {
        _wait = new WaitForSeconds(0.1f);
        _stateMachine = GetComponent<PlayerStateMachine>();
        _player = GetComponent<Player>();
    }

    public override IEnumerator Execute() {
        Debug.Log("IdleState");
        while (true) {
            if (_player.IsGrounded && Input.GetButtonDown("Jump")) {
                _stateMachine.ChangeState(PlayerStateMarkers.Jump);
                break;
            }
            if (Input.GetButtonDown("Horizontal") | Input.GetButtonDown("Vertical")) {
                _stateMachine.ChangeState(PlayerStateMarkers.Move);
                break;
            }
            yield return null;
        }
    }
}
