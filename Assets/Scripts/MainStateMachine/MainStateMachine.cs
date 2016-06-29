using UnityEngine;

public class MainStateMachine : MonoBehaviour {
    
    private IMainState CurrentState;

    private void Awake() {
        if (CurrentState == null) {
            ChangeState(new MainMenuLoadState());
        }
    }
        
    public void ChangeState(IMainState state) {
        StopCoroutine("Execute");
        CurrentState = state;
        StartCoroutine(CurrentState.Execute());
    }    
}
