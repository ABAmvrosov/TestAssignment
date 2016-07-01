using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour {

	private static Dictionary<GameObject, Stack<GameObject>> _pools = new Dictionary<GameObject, Stack<GameObject>>();  
	private static Dictionary<GameObject, GameObject> _spawnedToPrefab = new Dictionary<GameObject, GameObject>();

	public static void CreatePool(GameObject prefab) {
		CreatePool(prefab, 1);
	}

    public static void CreatePool(GameObject prefab, int quantity) {
        var stack = GetPool(prefab);
        if (stack != null) {
            Push(stack, prefab, quantity);
        } else {
            stack = new Stack<GameObject>();
			_pools.Add(prefab, stack);
            Push(stack, prefab, quantity);
        }
    }

    private static Stack<GameObject> GetPool(GameObject prefab) {
        Stack<GameObject> stack;
        _pools.TryGetValue(prefab, out stack);
        return stack;
    }

    private static void Push(Stack<GameObject> stack, GameObject prefab, int quantity) {
        for (int i = 0; i < quantity; i++) {
			GameObject tmp = Instantiate(prefab);
            stack.Push(tmp);
        }
    }

	public static GameObject Spawn(GameObject prefab) {
		return Spawn(prefab, Vector3.zero);
	}

    public static GameObject Spawn(GameObject prefab, Vector3 position) {
        var stack = GetPool(prefab);
        if (stack != null) {
			GameObject spawned = TryToSpawn(stack, prefab);
			_spawnedToPrefab.Add(spawned, prefab);
            spawned.transform.position = position;
			spawned.SetActive(true);
            return spawned;
        } else {
			CreatePool(prefab, 1);
			return Spawn(prefab, position);
        }
    }

	private static GameObject TryToSpawn(Stack<GameObject> stack, GameObject prefab) {
		if (stack.Count == 0) {
			GameObject result = Instantiate (prefab);
			stack.Push (result);
			return result;
		} else {
			return stack.Pop();
		}
	}

    public static void Return(GameObject obj) {		
		GameObject prefab;
		_spawnedToPrefab.TryGetValue(obj, out prefab);
		_spawnedToPrefab.Remove(obj);
		var stack = GetPool(prefab);
		if (stack != null) {
			stack.Push (obj);
			obj.SetActive (false);
		} else {
			Destroy(obj);
		}
    }
}