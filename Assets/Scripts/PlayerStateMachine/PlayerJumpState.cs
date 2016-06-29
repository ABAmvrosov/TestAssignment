using UnityEngine;
using System.Collections;
using System;

public class PlayerJumpState : PlayerState {

    private LayerMask _ground;
    private float _distToGround;
    private WaitForSeconds _wait;

    private void Awake() {
        _stateMachine = GetComponent<PlayerStateMachine>();
        _player = GetComponent<Player>();
        _ground = LayerMask.GetMask("Ground");
        _distToGround = GetComponent<SphereCollider>().bounds.extents.y + 0.1f;
        _wait = new WaitForSeconds(0.1f);
    }

    public override IEnumerator Execute() {
        Debug.Log("JumpState");
        _player.IsGrounded = false;
        Messenger.Broadcast("Jump");
        yield return _wait;
        StartCoroutine(Fall());
        _stateMachine.ChangeState(PlayerStateMarkers.Idle);
    }

    private IEnumerator Fall() {
        while (!_player.IsGrounded) {
            _player.IsGrounded = Physics.Raycast(transform.position, Vector3.down, _distToGround, _ground);
            yield return _wait;
        }
    }
}
