using UnityEngine;
using System.Collections;
using System;

public class PlayerFallState : PlayerState {

    private LayerMask _ground;
    private float _distToGround;

    public PlayerFallState(Player player, PlayerStateMachine stateMachine) {
        _stateMachine = stateMachine;
        _player = player;
        _ground = LayerMask.GetMask("Ground");
        _distToGround = player.gameObject.GetComponent<SphereCollider>().bounds.extents.y + 0.1f;
    }

    public override IEnumerator Execute() {
        Debug.Log("FallState");
        yield return new WaitForSeconds(0.1f);
        while (!_player.IsGrounded) {
            _player.IsGrounded = Physics.Raycast(_player.transform.position, Vector3.down, _distToGround, _ground);
            yield return null;
        }
        _stateMachine.ChangeState(PlayerStateMarkers.Idle);
    }
}
