using UnityEngine;
using System.Collections;

public class MainCameraFollow : MonoBehaviour {

	[SerializeField] private Transform _target;
    private Vector3 offset;

    private void Awake() {
        offset = transform.position - _target.transform.position;
        StartCoroutine(UpdatePosition());
    }

    private IEnumerator UpdatePosition() {
        while (true) {
            transform.position = _target.position + offset;
            yield return null;
        }
    }
}
