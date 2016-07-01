using UnityEngine;
using System.Collections;

public abstract class Weapon : MonoBehaviour {

    protected Vector3 ShotDirection {
        get {
            return (new Vector3(CameraTransform.position.x, PlayerTransform.position.y, CameraTransform.position.y) - PlayerTransform.position);
        }
    }
    private Transform CameraTransform {
        get { return Camera.main.transform; }
    }
    private Transform PlayerTransform {
        get { return _player.transform; }
    }
    protected GameObject _player;
            
    public abstract void Shoot();
}
