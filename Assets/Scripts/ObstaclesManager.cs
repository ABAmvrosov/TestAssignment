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
    private Dictionary<GameObject, Stack<GameObject>> _obstaclesPool;
    private WaitForSeconds _wait;

    private void Awake() {
        _wait = new WaitForSeconds(_spawnSpeed);
        _obstaclesPool = new Dictionary<GameObject, Stack<GameObject>>();
        _obstaclesPool.Add(_pickUpObstacle, new Stack<GameObject>());
        _obstaclesPool.Add(_unpathableObstacle1, new Stack<GameObject>());
        _obstaclesPool.Add(_unpathableObstacle2, new Stack<GameObject>());
        InitPool(_pickUpObstacle, 2);
        InitPool(_unpathableObstacle1, 10);
        InitPool(_unpathableObstacle2, 10);
        Messenger<GameObject>.AddListener("ReturnToPool", ReturnToPool);
        StartCoroutine(Spawn());
    }

    private void InitPool(GameObject prefab, int size) {
        Stack<GameObject> stack;
        _obstaclesPool.TryGetValue(prefab, out stack);
        for (int i = 0; i < size; i++) {
            stack.Push(Instantiate(prefab));
        }
    }

    private IEnumerator Spawn() {
        GameObject[] spawns = { _pickUpObstacle, _unpathableObstacle1, _unpathableObstacle2 };
        Stack<GameObject> stack;
        GameObject tmp;
        while (true) {
            yield return _wait;
            tmp = spawns[Random.Range(0, spawns.Length)];
            _obstaclesPool.TryGetValue(tmp, out stack);
            if (stack.Count > 0) {
                GameObject spawned = stack.Pop();
                spawned.SetActive(true);
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
    }

    //TODO: Not working.
    public void ReturnToPool(GameObject gameObject) {
        Stack<GameObject> stack;
        _obstaclesPool.TryGetValue(gameObject, out stack);
        Debug.Log(gameObject.name);
        if (stack != null) {
            stack.Push(gameObject);
            Debug.Log("Returned " + gameObject);
        }
    }
}
