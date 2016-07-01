using UnityEngine;
using System.Collections;

public class WeaponFireBall : Weapon {

    [SerializeField] private GameObject _projectilePrefab;
    [SerializeField] private float _speed;

    private void Awake() {
		ObjectPool.CreatePool(_projectilePrefab, 40);
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    public override void Shoot() {
        var projectile =  ObjectPool.Spawn(_projectilePrefab, transform.position);
        StartCoroutine(Fly(projectile, ShotDirection));
        Debug.Log("FireBall shot");
    }

    private IEnumerator Fly(GameObject projectile, Vector3 direction) {
		StartCoroutine(DestroyProjectile (projectile, 3.0f));
        while (true) {
            projectile.transform.Translate(direction * _speed * Time.deltaTime);
            yield return null;
        }
    }

    public override string ToString() {
        return "FireBall";
    }

	private IEnumerator DestroyProjectile(GameObject projectile, float time) {
		yield return new WaitForSeconds(time);
		ObjectPool.Return(projectile);
	}
}
