using System.Collections;
using UnityEngine;

public enum PlayerStateMarkers { Idle, Move, Jump, Fall }

public class PlayerStateMachine : MonoBehaviour {

    private PlayerState _baseState;
    private PlayerState _idleState;
    private PlayerState _moveState;
    private PlayerState _jumpState;
    private PlayerState _fallState;
    private IEnumerator _coroutine;

    private void Awake() {
        Player player = GetComponent<Player>();
        _baseState = new PlayerState();
        _idleState = new PlayerIdleState(player, this);
        _moveState = new PlayerMoveState(player, this);
        _jumpState = new PlayerJumpState(player, this);
        _fallState = new PlayerFallState(player, this);
        StartCoroutine(_baseState.Execute());
        _coroutine = _idleState.Execute();
        StartCoroutine(_coroutine);
    }

    public void ChangeState(PlayerStateMarkers state) {
        StopCoroutine(_coroutine);
        _coroutine = GetState(state).Execute();
        StartCoroutine(_coroutine);
    }

    private PlayerState GetState(PlayerStateMarkers state) {
        switch (state) {
            case PlayerStateMarkers.Idle:
                return _idleState;
            case PlayerStateMarkers.Move:
                return _moveState;
            case PlayerStateMarkers.Jump:
                return _jumpState;
            case PlayerStateMarkers.Fall:
                return _fallState;
        }
        return null;
    }
}
