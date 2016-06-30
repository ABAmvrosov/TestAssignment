using UnityEngine;
using System.Collections;

public class PlayGameState : IMainState {

    private ObstaclesManager _obstacleManager;

    public IEnumerator Execute() {
        yield return null;
    }
}
