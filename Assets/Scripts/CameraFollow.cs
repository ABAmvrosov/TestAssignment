using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	[SerializeField] private Transform _player;
    private Vector3 offset;

    private void Awake() {
        offset = transform.position - _player.transform.position;
        StartCoroutine(UpdatePosition());
    }

    private IEnumerator UpdatePosition() {
        while (true) {
            transform.position = _player.position + offset;
            yield return null;
        }
    }
}
