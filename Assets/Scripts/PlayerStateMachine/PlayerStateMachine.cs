using UnityEngine;

public enum PlayerStateMarkers { Idle, Move, Jump }

public class PlayerStateMachine : MonoBehaviour {

    private PlayerState CurrentState;
    private PlayerState _idleState;
    private PlayerState _moveState;
    private PlayerState _jumpState;

    private void Awake() {
        _idleState = GetComponent<PlayerIdleState>() as PlayerState;
        _moveState = GetComponent<PlayerMoveState>() as PlayerState;
        _jumpState = GetComponent<PlayerJumpState>() as PlayerState;
        ChangeState(PlayerStateMarkers.Idle);
    }

    public void ChangeState(PlayerStateMarkers state) {
        StopCoroutine("Execute");
        CurrentState = GetState(state);
        StartCoroutine(CurrentState.Execute());
    }

    private PlayerState GetState(PlayerStateMarkers state) {
        switch (state) {
            case PlayerStateMarkers.Idle:
                return _idleState;
            case PlayerStateMarkers.Move:
                return _moveState;
            case PlayerStateMarkers.Jump:
                return _jumpState;
        }
        return null;
    }
}
