using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    private Text _scoreText;
    private int _score;

    private void Awake() {
        _scoreText = GetComponent<Text>();
        Messenger.AddListener("PickUp", UpdateScore);
    }

    private void UpdateScore() {
        _scoreText.text = (++_score).ToString();
    }
}
