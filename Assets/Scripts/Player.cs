using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {

    public bool IsGrounded { get; set; }
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _speed;
    [SerializeField] private float _maxSpeed;
    private Rigidbody _rigidbody;
    [SerializeField] private Text _weapon;
    private List<Weapon> _weapons;
    private int _currentWeapon;

    private void Awake() {
        IsGrounded = true;
        _rigidbody = GetComponent<Rigidbody>();
        _currentWeapon = 0;
        _weapons = new List<Weapon> { GetComponent<WeaponFireBall>(), GetComponent<WeaponRailGun>(), GetComponent<WeaponGrenade>() };
        _weapon.text = _weapons[_currentWeapon].ToString();
    }

    public void Jump() {
        _rigidbody.AddForce(new Vector2(0, _jumpForce));
    }

    public void Move() {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0F, moveVertical);
        _rigidbody.AddForce(movement * _speed);
        if (_rigidbody.velocity.magnitude > _maxSpeed)
            _rigidbody.velocity = _rigidbody.velocity.normalized * _maxSpeed;
    }

    public void Shoot() {
        _weapons[_currentWeapon].Shoot();
    }

    public void ChangeWeapon() {
        if (Input.GetAxis("Mouse ScrollWheel") > 0) {
            NextWeapon();
        } else {
            PrevWeapon();
        }
    }

    private void NextWeapon() {
        if (_currentWeapon >= _weapons.Count - 1) {
            _currentWeapon = 0;
        } else {
            _currentWeapon += 1;
        }
        _weapon.text = _weapons[_currentWeapon].ToString();
    }

    private void PrevWeapon() {
        if (_currentWeapon - 1 < 0) {
            _currentWeapon = _weapons.Count - 1;
        } else {
            _currentWeapon -= 1;
        }
        _weapon.text = _weapons[_currentWeapon].ToString();
    }
}
