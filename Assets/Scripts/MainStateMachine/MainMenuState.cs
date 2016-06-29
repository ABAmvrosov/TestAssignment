using UnityEngine;
using System.Collections;

public class MainMenuState : IMainState {

    private bool _idle = true;
    private WaitForSeconds _wait = new WaitForSeconds(0.5f);
    private string levelName;

    public MainMenuState() {
        Messenger<string>.AddListener("LoadLevel", LoadLevel);
    }

    public IEnumerator Execute() {
        while (_idle) {
            yield return _wait;
        }
        GameManager.Instance.StateMachine.ChangeState(new LoadLevelState(levelName));
    }

    private void LoadLevel(string levelToLoad) {
        levelName = levelToLoad;
        _idle = false;
        Debug.Log("Trying to load level");
    }
}
