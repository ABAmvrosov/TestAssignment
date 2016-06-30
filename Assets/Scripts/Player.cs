using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public bool IsGrounded { get; set; }
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _speed;
    [SerializeField] private float _maxSpeed;
    private Rigidbody _rigidbody;

    private void Awake() {
        IsGrounded = true;
        _rigidbody = GetComponent<Rigidbody>();
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
}
