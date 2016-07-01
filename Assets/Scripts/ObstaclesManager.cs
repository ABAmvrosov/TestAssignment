using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObstaclesManager : MonoBehaviour {
    
    [SerializeField] private Transform _player;
    [SerializeField] private float _spawnSpeed;
    [SerializeField] private float xMax;
    [SerializeField] private float zMax;
    [SerializeField] private float _offset;
    [SerializeField] private GameObject _pickUpObstacle;
    [SerializeField] private GameObject _unpathableObstacle1;
    [SerializeField] private GameObject _unpathableObstacle2;
    private WaitForSeconds _wait;

    private void Awake() {
        _wait = new WaitForSeconds(_spawnSpeed);
		ObjectPool.CreatePool(_pickUpObstacle, 20);
		ObjectPool.CreatePool(_unpathableObstacle1, 10);
		ObjectPool.CreatePool(_unpathableObstacle2, 10);
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn() {
		GameObject[] randomPool = { _pickUpObstacle, _pickUpObstacle, _pickUpObstacle, _unpathableObstacle1, _unpathableObstacle2 };
        GameObject prefab;
        while (true) {
            yield return _wait;
			prefab = randomPool[Random.Range(0, randomPool.Length)];
			GameObject spawned = ObjectPool.Spawn(prefab);
			SetPosition(spawned);
        }
    }

	private void SetPosition(GameObject spawned) {
		float x = Random.Range(-xMax, xMax);
		float z = Random.Range(-zMax, zMax);
		Vector3 position = new Vector3(x, 0.5f, z);
		Vector3 direction = position - _player.position;
		if (direction.sqrMagnitude < (_offset * _offset)) {
			float distance = _offset - direction.magnitude;
			spawned.transform.position = position;
			spawned.transform.Translate(direction.normalized * distance);
		} else {
			spawned.transform.position = position;
		}
	}
}
