using UnityEngine;
using System.Collections;

public class PickUp : MonoBehaviour {

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            this.gameObject.SetActive(false);
            Messenger<GameObject>.Broadcast("ReturnToPool", this.gameObject);
            Messenger.Broadcast("PickUp");
        }
    }
}
