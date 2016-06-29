using System.Collections;
using UnityEngine;
using System;

public abstract class PlayerState : MonoBehaviour {

    protected PlayerStateMachine _stateMachine;
    protected Player _player;
    
    public abstract IEnumerator Execute();
}
