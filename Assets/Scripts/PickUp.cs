using UnityEngine;
using System.Collections;

public class PickUp : MonoBehaviour {

    private void OnTriggerEnter(Collider other) {
        Debug.Log("Collision");
        if (other.tag == "Player") {
            this.gameObject.SetActive(false);
        }
    }
}
