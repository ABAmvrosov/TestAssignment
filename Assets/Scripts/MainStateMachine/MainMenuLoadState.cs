using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuLoadState : IMainState {

    AsyncOperation asyncLoadLevel;
        
    public MainMenuLoadState() {
        SceneManager.LoadScene("MainMenuLoadScreen", LoadSceneMode.Single);
    }

    public IEnumerator Execute() {
        asyncLoadLevel = SceneManager.LoadSceneAsync("MainMenu", LoadSceneMode.Single);
        while (!asyncLoadLevel.isDone) {
            yield return null;
        }
        GameManager.Instance.StateMachine.ChangeState(new MainMenuState());
    }
}
