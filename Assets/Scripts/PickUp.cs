using UnityEngine;
using System.Collections;

public class PickUp : MonoBehaviour {

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            this.gameObject.SetActive(false);
			ObjectPool.Return(this.gameObject);
            Messenger.Broadcast("PickUp");
        }
    }
}
