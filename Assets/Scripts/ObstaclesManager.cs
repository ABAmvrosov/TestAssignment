using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObstaclesManager : MonoBehaviour {

    [SerializeField] private GameObject[] _obstaclesPrefabs;
    private Stack<GameObject>[] _obstaclesPool;
    [SerializeField] private float _spawnSpeed;
    [SerializeField] private Transform _player;
    private WaitForSeconds _wait;
    [SerializeField] private int _poolSize;
    [SerializeField] private float xMax;
    [SerializeField] private float zMax;
    [SerializeField] private float _offset;

    private void Awake() {
        _wait = new WaitForSeconds(_spawnSpeed);
        _obstaclesPool = new Stack<GameObject>[_obstaclesPrefabs.Length];
        for (int i = 0; i < _obstaclesPrefabs.Length; i++) {
            _obstaclesPool[i] = new Stack<GameObject>();
            for (int j = 0; j < _poolSize; j++) {
                _obstaclesPool[i].Push(Instantiate(_obstaclesPrefabs[i]));
            }
        }
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn() {
        while (true) {
            yield return _wait;
            int index = Random.Range(0, _obstaclesPrefabs.Length);
            if (_obstaclesPool[index].Count > 0) {
                GameObject spawned = _obstaclesPool[index].Pop();
                float x = Random.Range(-xMax, xMax);
                float z = Random.Range(-zMax, zMax);
                Vector3 position = new Vector3(x, 0.5f, z);
                if ((position - _player.position).sqrMagnitude < (_offset * _offset)) {

                }
                spawned.transform.position = position;
            }
        }
    }
}
