using UnityEngine;
using System.Collections;

public class WeaponFireBall : Weapon {

    [SerializeField] private GameObject _projectilePrefab;
    [SerializeField] private float _speed;

    private void Awake() {
        ObjectPool.Add(_projectilePrefab, 20);
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    public override void Shoot() {
        var projectile =  ObjectPool.Spawn(_projectilePrefab, transform.position);
        projectile.SetActive(true);
        StartCoroutine(Fly(projectile, ShotDirection));
        Debug.Log("FireBall shot");
    }

    //TODO: Make timer;
    private IEnumerator Fly(GameObject projectile, Vector3 direction) {
        while (true) {
            projectile.transform.Translate(direction * _speed * Time.deltaTime);
            yield return null;
        }
    }

    public override string ToString() {
        return "FireBall";
    }
}
