using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager Instance { get; set; }

    public MainStateMachine StateMachine {
        get { return _mainStateMachine; }
    }
    private MainStateMachine _mainStateMachine;    

    private void Awake() {
        if (Instance == null)
            Instance = this;
        if (_mainStateMachine == null)
            _mainStateMachine = GetComponent<MainStateMachine>();
        DontDestroyOnLoad(Instance);
    }
}
