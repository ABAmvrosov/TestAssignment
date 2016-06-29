using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public bool IsGrounded { get; set; }
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _speed;
    private Rigidbody _rigidbody;

    private void Awake() {
        _rigidbody = GetComponent<Rigidbody>();
        IsGrounded = true;
        Messenger.AddListener("Jump", Jump);
        Messenger.AddListener("Move", Move);
    }

    private void Jump() {
        _rigidbody.AddForce(new Vector2(0, _jumpForce));
    }

    private void Move() {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0F, moveVertical);

        _rigidbody.AddForce(movement * _speed);
    }
}
