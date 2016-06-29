using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadLevelState : IMainState {

    private AsyncOperation asyncLoadLevel;
    private string levelName;

    public LoadLevelState(string levelName) {
        this.levelName = levelName;
    }

    public IEnumerator Execute() {
        asyncLoadLevel = SceneManager.LoadSceneAsync(levelName, LoadSceneMode.Single);
        while (!asyncLoadLevel.isDone) {
            yield return null;
        }
        GameManager.Instance.StateMachine.ChangeState(new PlayGameState());
    }
}
