using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour {

    private static Dictionary<string, Stack<GameObject>> _pools = new Dictionary<string, Stack<GameObject>>();  

    public static void Add(GameObject prefab, int quantity) {
        var stack = GetPool(prefab);
        if (stack != null) {
            Push(stack, prefab, quantity);
        } else {
            stack = new Stack<GameObject>();
            _pools.Add(GetName(prefab), stack);
            Push(stack, prefab, quantity);
        }
    }

    private static Stack<GameObject> GetPool(GameObject prefab) {
        Stack<GameObject> stack;
        string name = GetName(prefab);
        _pools.TryGetValue(name, out stack);
        return stack;
    }

    private static string GetName(GameObject prefab) {
        return prefab.name;
    }

    private static void Push(Stack<GameObject> stack, GameObject prefab, int quantity) {
        for (int i = 0; i < quantity; i++) {
            stack.Push(Instantiate(prefab));
        }
    }

    public static GameObject Spawn(GameObject prefab, Vector3 position) {
        var stack = GetPool(prefab);
        if (stack != null) {
            GameObject spawned = stack.Pop();
            spawned.transform.position = position;
            return spawned;
        } else {
            Debug.LogError("Pool of " + prefab.name + "not created!");
            return null;
        }
    }

    public static void Return(GameObject obj) {
        var stack = GetPool(obj);
        if (stack != null)
            stack.Push(obj);
    }
}
